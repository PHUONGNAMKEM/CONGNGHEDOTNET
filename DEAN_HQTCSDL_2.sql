/*=============================================================================================================*/
-- TẠO THỦ TỤC TẠO NGƯỜI DÙNG (CREATE USER)
CREATE PROC CREATE_USER 
    @USERNAME VARCHAR(30), 
    @PASSWORD VARCHAR(30),
	@DATABASE VARCHAR(30)
AS
BEGIN
    -- Tạo câu lệnh động để tạo login - câu lệnh sql thay đổi tùy theo chức năng
    DECLARE @sql NVARCHAR(MAX);
    BEGIN TRY
         -- Tạo login - Databases
		SET @sql = 'CREATE LOGIN [' + @USERNAME + '] WITH PASSWORD = ''' + @PASSWORD + ''';';
		EXEC sp_executesql @sql;
    
		-- Tạo user cho login - database của mình
		SET @sql = 'CREATE USER [' + @USERNAME + '] FOR LOGIN [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
	
		-- GÁN QUYỀN CHO USER ĐƯỢC THAO TÁC TRÊN VIEW (NHANVIEN_COPY, KHACHHANG_VIEW, HOADON_VIEW)
		-- Gán quyền SELECT, INSERT, UPDATE, DELETE cho View NHANVIEN_COPY
		SET @sql = 'USE [' + @DATABASE + ']; GRANT SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[NHANVIEN_COPY] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Gán quyền SELECT, INSERT, UPDATE, DELETE cho View KHACHHANG_VIEW
		SET @sql = 'USE [' + @DATABASE + ']; GRANT SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[KHACHHANG_VIEW] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Gán quyền SELECT, INSERT, UPDATE, DELETE cho View HOADON_VIEW
		SET @sql = 'USE [' + @DATABASE + ']; GRANT SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[HOADON_VIEW] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;

		-- Gán quyền SELECT, INSERT, UPDATE, DELETE cho BẢNG USERSESSIONS
		SET @sql = 'USE [' + @DATABASE + ']; GRANT SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[UserSessions] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;

		-- Gán quyền EXECUTE cho USER
		SET @sql = 'USE [' + @DATABASE + ']; GRANT EXECUTE TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;

		-- TỪ CHỐI QUYỀN CỦA USER TRÊN TẤT CẢ BẢNG THỰC
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng CHITIETHOADON
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[CHITIETHOADON] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng CHITIETPN
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[CHITIETPN] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng HANGHOA
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[HANGHOA] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng HOADON
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[HOADON] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng KHACHHANG
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[KHACHHANG] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng LOAIHANG
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[LOAIHANG] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng NHACC
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[NHACC] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng NHANVIEN
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[NHANVIEN] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng PHIEUNHAP
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[PHIEUNHAP] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
    
		-- Từ chối quyền SELECT, INSERT, UPDATE, DELETE cho bảng THONGTINNHANVIEN
		SET @sql = 'USE [' + @DATABASE + ']; DENY SELECT, INSERT, UPDATE, DELETE ON OBJECT::[dbo].[THONGTINNHANVIEN] TO [' + @USERNAME + '];';
		EXEC sp_executesql @sql;
        RETURN 1;
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi và trả về 0 nếu thất bại
        RETURN 0;
    END CATCH
END
GO

--SELECT * FROM sys.database_principals
--DROP USER nam4

-- TẠO THỦ TỤC CẤP QUYỀN CRUD
CREATE PROC GRANT_PERMISSION 
    @USERNAME VARCHAR(30), 
    @PASSWORD VARCHAR(30)
AS
BEGIN
    -- Tạo câu lệnh động để tạo login - câu lệnh sql thay đổi tùy theo chức năng
    DECLARE @sql NVARCHAR(MAX);
    
    -- Gán quyền thêm cho user đã được tạo trước đó
    SET @sql = 'GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE TO [' + @USERNAME + '];';
    EXEC sp_executesql @sql;
END
GO
-- TẠO THỦ TỤC CẤP QUYỀN ADMIN
CREATE PROC GRANT_PERMISSION_ADMIN
    @USERNAME VARCHAR(30)
AS
BEGIN
    -- Tạo câu lệnh động để tạo login - câu lệnh sql thay đổi tùy theo chức năng
    DECLARE @sql NVARCHAR(MAX);
    
    -- Gán quyền admin cho user
    SET @sql = 'ALTER ROLE db_owner ADD MEMBER [' + @USERNAME + '];';
	EXEC sp_executesql @sql;
END
GO


CREATE PROC DISPLAY_HANGHOA
AS
	SELECT * FROM HANGHOA

EXEC DISPLAY_HANGHOA 

GO
-- 4.2. Thêm một hàng hóa
CREATE PROC INSERT_HANGHOA @TENHANG NVARCHAR(50), @DVT NVARCHAR(30), @MALOAI INT
AS
	INSERT INTO HANGHOA VALUES (@TENHANG, @DVT, @MALOAI)
	
GO

-- 4.3. Xóa một hàng hóa
CREATE PROC DELETE_HANGHOA @MAHG CHAR(10)
AS
	DELETE
	FROM HANGHOA
	WHERE MAHG = @MAHG

GO
-- 4.4. Sửa một hàng hóa
CREATE PROC UPDATE_HANGHOA @MAHG_OLD CHAR(10), @MAHG_NEW CHAR(10), @TENHANG NVARCHAR(50), @DVT NVARCHAR(30), @MALOAI CHAR(10)
AS
	UPDATE HANGHOA
	SET MAHG = @MAHG_NEW, TENHANG = @TENHANG, DVT = @DVT, MALOAI = @MALOAI 
	WHERE MAHG = @MAHG_OLD

EXEC UPDATE_HANGHOA 'HG009', 'HG009', N'AI BIT 2', N'Thùng', 'LT002'
SELECT * FROM HANGHOA

select * from KHACHHANG_VIEW

-- 2. TẠO THỦ TỤC CHO VIEW HOADON
-- 2.1. Hiển thị thông tin hóa đơn
CREATE VIEW	HOADON_VIEW
AS 
	SELECT * FROM HOADON

GO

CREATE PROC DISPLAY_HOADON_VIEW
AS
	SELECT * FROM HOADON_VIEW

EXEC DISPLAY_HOADON_VIEW

GO
-- 2.2. Thêm một hóa đơn
CREATE PROC INSERT_HOADON_VIEW @MAHD CHAR(10), @NGAYLAP DATE, @TRANGTHAI NVARCHAR(30), @MAKH CHAR(10), @MANV CHAR(10) 
AS
	INSERT INTO HOADON_VIEW VALUES (@MAHD, @NGAYLAP, @TRANGTHAI, @MAKH, @MANV)

GO

-- EXEC INSERT_HOADON_VIEW 'HD001', '2024/09/10', N'Còn hàng', 'KH001', 'NV002'
-- 2.3. Xóa một hóa đơn
CREATE PROC DELETE_HOADON_VIEW @MAHD CHAR(10)
AS	
	DELETE 
	FROM HOADON_VIEW 
	WHERE MAHD = @MAHD

GO

-- EXEC DELETE_HOADON_VIEW 'HD003'
-- 2.4. Sửa một hóa đơn
CREATE PROC UPDATE_HOADON_VIEW @MAHD_OLD CHAR(10), @MAHD_NEW CHAR(10), @NGAYLAP DATE, @TRANGTHAI NVARCHAR(30), @MAKH CHAR(10), @MANV CHAR(10) 
AS
	UPDATE HOADON_VIEW
	SET MAHD = @MAHD_NEW, NGAYLAP = @NGAYLAP, TRANGTHAI = @TRANGTHAI, MAKH = @MAKH, MANV = @MANV 
	WHERE MAHD = @MAHD_OLD

-- EXEC UPDATE_HOADON_VIEW 'HD001', 'HD007', '2024/09/10', N'Còn hàng', 'KH001', 'NV001'

GO
-- 3. TẠO THỦ TỤC CHO BẢNG 
CREATE VIEW NHANVIEN_COPY
AS
	SELECT * FROM NHANVIEN

GO

-- TẠO VIEW CHO BẢNG KHACHHANG
-- 3.1. Hiển thị thông tin bảng nhanvien
CREATE PROC DISPLAY_NHANVIEN_VIEW 
AS 
	SELECT * FROM NHANVIEN_COPY

EXEC DISPLAY_NHANVIEN

GO
-- 3.2. Thêm một nhân viên
CREATE PROC INSERT_NHANVIEN_VIEW @MANV CHAR(10), @TENNV NVARCHAR(50), @CHUCVU NVARCHAR(30), @MANV_QUANLY CHAR(10)
AS
	INSERT INTO NHANVIEN_COPY VALUES (@MANV, @TENNV, @CHUCVU, @MANV_QUANLY)

--EXEC INSERT_NHANVIEN_VIEW
GO

-- 3.3. Xóa một nhân viên
CREATE PROC DELETE_NHANVIEN_VIEW @MANV CHAR(10)
AS
	DELETE
	FROM NHANVIEN_COPY
	WHERE MANV = @MANV

GO
-- 3.4. Sửa một nhân viên

CREATE PROC UPDATE_NHANVIEN_VIEW @MANV_OLD CHAR(10), @MANV_NEW CHAR(10), @TENNV NVARCHAR(50), @CHUCVU NVARCHAR(30), @MANV_QUANLY CHAR(10)
AS
	--IF NOT EXISTS(SELECT 1 FROM NHANVIEN_COPY WHERE MANV = @MANV_OLD)
	UPDATE NHANVIEN_COPY 
	SET MANV = @MANV_NEW, TENNV = @TENNV, CHUCVU = @CHUCVU, MANV_QUANLY = @MANV_QUANLY 
	WHERE MANV = @MANV_OLD

EXEC UPDATE_NHANVIEN_VIEW 'NV0013', 'NV002', N'NGUYENVAN2', N'GIAMDOC2', 'NV003'
SELECT * FROM NHANVIEN_COPY

GO

/*Thủ tục có tham số*/
CREATE PROC HANG_CHUA_BAN_VA_TONG
    @TongSoLuongChuaBan INT OUTPUT
AS
BEGIN
    SELECT HANGHOA.MAHG, HANGHOA.TENHANG, DVT, MALOAI, TONG_NHAP.TONG_NHAP
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
/*Thủ tục sử dụng cấu trúc rẽ nhánh, cấu trúc lặp hoặc các hàm có sẵn*/
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
            SET @rank = N'Khách hàng đã được nâng cấp lên thành viên kim cương.';
        END
		ELSE IF @tong_chi_tieu >= 10000000
        BEGIN
            SET @rank = N'Khách hàng đã được nâng cấp lên thành viên vàng.';
        END
		ELSE IF @tong_chi_tieu >= 5000000
        BEGIN
            SET @rank = N'Khách hàng đã được nâng cấp lên thành viên bạc.';
        END
        ELSE IF @tong_chi_tieu >= 2000000
        BEGIN
           SET @rank = N'Khách hàng đã được nâng cấp lên thành viên đồng.';
        END
		ELSE
		BEGIN
           SET @rank = N'Khách hàng thường.';
        END

    END
    ELSE
    BEGIN
         Print N'Không tìm thấy khách hàng với mã đã cung cấp.';
    END
END;

GO
DECLARE @TONGTIEN FLOAT, @RANK NVARCHAR(100), @TAM NVARCHAR(100)
EXEC P_GETLOAIKH 'KH002', @TONGTIEN OUTPUT, @RANK OUTPUT
PRINT N'Khách hàng đã chi tiêu tổng: '+CONVERT(NVARCHAR(30),CONVERT(numeric(16,0), CAST(@TONGTIEN AS FLOAT)))+' '+@RANK
/*Hàm  sử dung, cấu trúc lặp hoặc các hàm có sẵn*/
go
CREATE FUNCTION F_TinhTuoiNhanVien (@MaNV CHAR(15))
RETURNS INT
AS
BEGIN
    DECLARE @NgaySinh DATE;
    SELECT @NgaySinh = NGAYSINH FROM THONGTINNHANVIEN WHERE MANV = @MaNV;    
    RETURN DATEDIFF(YEAR, @NgaySinh, GETDATE());
END;
GO

DECLARE @TUOI INT
SET @TUOI=dbo.F_TinhTuoiNhanVien('NV001')
PRINT @TUOI

DECLARE @TUOI INT
SET @TUOI=dbo.F_TinhTuoiNhanVien('NV001          ')
PRINT @TUOI



select * from NHANVIEN
select * from THONGTINNHANVIEN
GO

/*Thủ tục sử dụng cấu trúc rẽ nhánh, cấu trúc lặp hoặc các hàm có sẵn*/
ALTER PROCEDURE P_GETLOAIKH
    @ma_khach CHAR(15),
    @tong_chi_tieu FLOAT OUTPUT,
	@rank NVARCHAR(200) OUTPUT
AS
BEGIN
    SET @tong_chi_tieu = 0;

    -- Kiểm tra xem khách hàng có tồn tại hay không
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
            SET @rank = N'Kim cương.';
        END
		ELSE IF @tong_chi_tieu >= 10000000
        BEGIN
            SET @rank = N'Vàng.';
        END
		ELSE IF @tong_chi_tieu >= 5000000
        BEGIN
            SET @rank = N'Bạc.';
        END
        ELSE IF @tong_chi_tieu >= 2000000
        BEGIN
           SET @rank = N'Đồng.';
        END
		ELSE
		BEGIN
           SET @rank = N'Thường.';
        END

    END
    ELSE
    BEGIN
         Print N'Không tìm thấy khách hàng với mã đã cung cấp.';
    END
END;

GO
DECLARE @TONGTIEN FLOAT, @RANK NVARCHAR(100), @TAM NVARCHAR(100)
EXEC P_GETLOAIKH 'KH002', @TONGTIEN OUTPUT, @RANK OUTPUT
PRINT N'Khách hàng đã chi tiêu tổng: '+CONVERT(NVARCHAR(30),CONVERT(numeric(16,0), CAST(@TONGTIEN AS FLOAT)))+' '+@RANK
/*Hàm  sử dung, cấu trúc lặp hoặc các hàm có sẵn*/
go
CREATE FUNCTION F_TinhTuoiNhanVien (@MaNV CHAR(15))
RETURNS INT
AS
BEGIN
    DECLARE @NgaySinh DATE;
    SELECT @NgaySinh = NGAYSINH FROM THONGTINNHANVIEN WHERE MANV = @MaNV;    
    RETURN DATEDIFF(YEAR, @NgaySinh, GETDATE());
END;
GO

DECLARE @TUOI INT
SET @TUOI=dbo.F_TinhTuoiNhanVien('NV001')
PRINT @TUOI

DECLARE @TUOI INT
SET @TUOI=dbo.F_TinhTuoiNhanVien('NV001')
PRINT @TUOI


--TẠO CURSOR LỘC RANK NGƯỜI DÙNG
go
CREATE PROCEDURE P_XUAT_HANG_KHACH_HANG
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
END;

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

    CLOSE khach_hang_cursor;
    DEALLOCATE khach_hang_cursor;

    -- Xuất toàn bộ dữ liệu từ bảng tạm
    SELECT * FROM @ResultTable;
END;

select * from NHANVIEN
select * from THONGTINNHANVIEN



