-- THỦ TỤC --
/*Thủ tục sử dụng cấu trúc rẽ nhánh, cấu trúc lặp hoặc các hàm có sẵn*/
-- XẾP LOẠI KHÁCH HÀNG -- KHACHHANG
ALTER PROCEDURE P_GETLOAIKH
    @ma_khach CHAR(15),
    @tong_chi_tieu FLOAT OUTPUT,
	@rank NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET @tong_chi_tieu = 0;

    -- Kiểm tra xem khách hàn	g có tồn tại hay không
    IF EXISTS (SELECT 1 FROM KHACHHANG WHERE MAKH = @ma_khach)
    BEGIN
        -- Tính tổng số tiền từ các hóa đơn của khách hàng
        SET @tong_chi_tieu = (
            SELECT SUM(SOLUONG * GIABAN)
            FROM CHITIETHOADON CT
            JOIN HOADON HD ON CT.MAHD = HD.MAHD
            WHERE HD.MAKH = @ma_khach
        );
        -- Nếu khách hàng không có giao dịch nào thì tổng chi tiêu vẫn là 0
        IF @tong_chi_tieu IS NULL
            SET @tong_chi_tieu = 0;

        -- Cập nhật trạng thái thành viên dựa trên tổng chi tiêu
        IF @tong_chi_tieu >= 20000000
        BEGIN
            SET @rank = N'Kim cương';
        END
		ELSE IF @tong_chi_tieu >= 10000000
        BEGIN
            SET @rank = N'Vàng';
        END
		ELSE IF @tong_chi_tieu >= 5000000
        BEGIN
            SET @rank = N'Bạc';
        END
        ELSE IF @tong_chi_tieu >= 2000000
        BEGIN
           SET @rank = N'Đồng';
        END
		ELSE
		BEGIN
           SET @rank = N'Thường';
        END

    END
    ELSE
    BEGIN
         Print N'Không tìm thấy khách hàng với mã đã cung cấp.';
    END
END;

GO
-- THỦ TỤC CÓ THAM SỐ VÀ OUTPUT
-- HÀNG CHƯA BÁN VÀ TỔNG SỐ LƯỢNG -- HANGHOA(LỒNG TƯƠNG QUAN) 
ALTER PROC HANG_CHUA_BAN_VA_TONG
    @TongSoLuongChuaBan INT OUTPUT
AS
BEGIN
    SELECT HANGHOA.MAHG, HANGHOA.TENHANG, DVT, MALOAI,DONGIA, HINH, TONG_NHAP.TONG_NHAP
    FROM HANGHOA
    JOIN TONG_NHAP ON HANGHOA.MAHG = TONG_NHAP.MAHG
    WHERE NOT EXISTS (
        SELECT * 
        FROM CHITIETHOADON
        WHERE CHITIETHOADON.MAHG = HANGHOA.MAHG
    );
    
    -- Tính tổng số lượng hàng chưa bán
    SELECT @TongSoLuongChuaBan = SUM(TONG_NHAP.TONG_NHAP)
    FROM HANGHOA
    JOIN TONG_NHAP ON HANGHOA.MAHG = TONG_NHAP.MAHG
    WHERE NOT EXISTS (
        SELECT * 
        FROM CHITIETHOADON
        WHERE CHITIETHOADON.MAHG = HANGHOA.MAHG
    );
END
GO
-- HÀNG BÁN CHẠY NHẤT --HANGHOA(LỒNG PHÂN CẤP)
CREATE PROC HANG_BAN_CHAY_NHAT
AS
	BEGIN
		SELECT CHITIETHOADON.MAHG, HANGHOA.TENHANG ,HANGHOA.DVT, HANGHOA.MALOAI, DONGIA, HINH,SUM(CHITIETHOADON.SOLUONG * CHITIETHOADON.GIABAN) AS DOANH_THU
		FROM CHITIETHOADON JOIN HANGHOA ON CHITIETHOADON.MAHG = HANGHOA.MAHG
		GROUP BY CHITIETHOADON.MAHG, HANGHOA.TENHANG ,HANGHOA.DVT, HANGHOA.MALOAI,DONGIA, HINH
		HAVING SUM(CHITIETHOADON.SOLUONG * CHITIETHOADON.GIABAN) >= ALL (
				SELECT SUM(CHITIETHOADON.SOLUONG * CHITIETHOADON.GIABAN)
				FROM CHITIETHOADON
				GROUP BY CHITIETHOADON.MAHG
    )
	END
GO

-- HÀM --
/*Hàm  sử dụng, cấu trúc lặp hoặc các hàm có sẵn*/ -- TÍNH TUỔI NHANVIEN
go
ALTER FUNCTION F_TinhTuoiNhanVien (@MaNV CHAR(15))
RETURNS INT
AS
BEGIN
    DECLARE @NgaySinh DATE;
    SELECT @NgaySinh = NGAYSINH FROM THONGTINNHANVIEN WHERE MANV = @MaNV;    
    RETURN DATEDIFF(YEAR, @NgaySinh, GETDATE());
END;
GO


-- TRIGGER --
-- KIỂM TRA HÀNG TỒN KHO (CHITIETHD)
ALTER PROC P_KIEMTRA_TONKHO @MAHD CHAR(20), @MAHG CHAR(20), @SOLUONG INT
AS
	BEGIN
		DECLARE @SOLUONGTONKHO INT
		SET @SOLUONGTONKHO =(SELECT SUM(SOLUONG) FROM  CHITIETPN WHERE MAHG=@MAHG)-(SELECT SUM(SOLUONG) FROM CHITIETHOADON WHERE MAHG=@MAHG)
		-- Kiểm tra sô lượng tồn kho
		IF((@SOLUONGTONKHO) < 0)
			BEGIN
				-- Thông báo lỗi và hủy bỏ việc thêm hóa đơn
				PRINT(N'Số lượng tồn kho của hàng hóa có mã ' +  RTRIM(@MAHG) + N' còn lại '+ CONVERT(NVARCHAR, ABS(@SOLUONGTONKHO + @SOLUONG))+ N' Số lượng không đủ để thêm hóa đơn này. ');
				ROLLBACK
			END

	END
GO

-- TRIGGER Ở ĐÂY NÈ - GỌI LẠI THỦ TỤC Ở TRÊN

GO
CREATE TRIGGER KT_SOLUONGTONKHO_HH
ON CHITIETHOADON
FOR INSERT, UPDATE
AS
BEGIN
	--Khai báo biến
    DECLARE @MAHG INT,@MAHD CHAR(100),@SOLUONG INT;	
    -- Lấy mã hàng và số lượng từ bản ghi mới được thêm
    SELECT @MAHD=MAHD, @MAHG = MAHG, @SOLUONG = SOLUONG FROM INSERTED;
	EXEC P_KIEMTRA_TONKHO @MAHD, @MAHG, @SOLUONG
END;
GO


-- CURSOR --
-- TÍNH HẠNG CỦA TẤT CẢ KHÁCH HÀNG (HẠNG ALL) - KHACHHANG
ALTER PROCEDURE P_XUAT_HANG_KHACH_HANG
AS
BEGIN
    DECLARE @ma_khach CHAR(15);
    DECLARE @ten_khach NVARCHAR(50);
    DECLARE @dia_chi NVARCHAR(50);
    DECLARE @sodt NVARCHAR(15);
    DECLARE @tong_chi_tieu FLOAT;
    DECLARE @rank NVARCHAR(200);

    -- Tạo bảng tạm để lưu kết quả
    DECLARE @ResultTable TABLE (
        MaKhach CHAR(15),
        TenKhach NVARCHAR(50),
        DiaChi NVARCHAR(50),
        SoDT NVARCHAR(15),
        TongChiTieu FLOAT,
        Rank NVARCHAR(200)
    );

    -- Khởi tạo con trỏ để lấy thông tin khách hàng
    DECLARE khach_hang_cursor CURSOR FOR
    SELECT MAKH, TENKH, DIACHI, SODT FROM KHACHHANG;

    OPEN khach_hang_cursor;

	FETCH NEXT FROM khach_hang_cursor INTO @ma_khach, @ten_khach, @dia_chi, @sodt;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Gọi thủ tục để tính toán tổng chi tiêu và hạng của khách hàng
        EXEC P_GETLOAIKH @ma_khach, @tong_chi_tieu OUTPUT, @rank OUTPUT;

        -- Thêm kết quả vào bảng tạm
        INSERT INTO @ResultTable (MaKhach, TenKhach, DiaChi, SoDT, TongChiTieu, Rank)
        VALUES (@ma_khach, @ten_khach, @dia_chi, @sodt, @tong_chi_tieu, @rank);

        FETCH NEXT FROM khach_hang_cursor INTO @ma_khach, @ten_khach, @dia_chi, @sodt;
	END
    CLOSE khach_hang_cursor;
    DEALLOCATE khach_hang_cursor;

    -- Xuất toàn bộ dữ liệu từ bảng tạm
    SELECT * FROM @ResultTable;
END;