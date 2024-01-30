USE master

CREATE DATABASE KASIR_RESTO

USE KASIR_RESTO

--Membuat table MENU
CREATE TABLE MENU
(
	id INT PRIMARY KEY IDENTITY(1,1),
	nama VARCHAR(100),
	kategori VARCHAR(100),
	harga INT,
	ketersediaan VARCHAR(100),
)

INSERT INTO MENU (nama, kategori, harga, ketersediaan)
VALUES ('Ayam Goreng Kemalaman', 'Makanan', 20000, 'Tersedia'),
	   ('Kraken Lada Hitam', 'Makanan', 85000, 'Tersedia'),
	   ('Krabby Patty', 'Makanan', 30000, 'Tersedia'),
	   ('Mashed Pottatoes', 'Makanan', 25000, 'Tersedia'),
	   ('Kentang Goreng Setan', 'Makanan', 25000, 'Tersedia'),
	   ('Sup Sapi Mengamuk', 'Makanan', 35000, 'Tidak Tersedia'),
	   ('Sup Ikan Tenggelam', 'Makanan', 30000, 'Tersedia'),
	   ('Kepiting Bakar', 'Makanan', 40000, 'Tersedia'),
	   ('Nasi Goreng Keenakan', 'Makanan', 20000, 'Tersedia'),
	   ('Anjing Panas (hotdog)', 'Makanan', 30000, 'Tersedia'),
	   ('Kopi Senja', 'Minuman', 15000, 'Tersedia'),
	   ('Teh Panas Dingin', 'Minuman', 15000, 'Tersedia'),
	   ('Soda Tidak Gembira', 'Minuman', 20000, 'Tersedia'),
	   ('Strawberry Junkie', 'Minuman', 25000, 'Tersedia'),
	   ('Hawaian Creamy', 'Minuman', 25000, 'Tersedia'),
	   ('Lemonade', 'Minuman', 15000, 'Tersedia'),
	   ('Jus Nanas', 'Minuman', 15000, 'Tersedia'),
	   ('Jus Alpukat', 'Minuman', 15000, 'Tidak Tersedia'),
	   ('Air Mineral', 'Minuman', 5000, 'Tersedia'),
	   ('Ice Cream 1 Ton', 'Lainnya', 20000, 'Tersedia'),
	   ('Ice Cake (Ice Cream Pancake)', 'Lainnya', 25000, 'Tersedia'),
	   ('Pancake Pencakar Langit', 'Lainnya', 50000, 'Tersedia'),
	   ('Kue Blackforest', 'Lainnya', 50000, 'Tersedia'),
	   ('Kue Whiteforest', 'Lainnya', 50000, 'Tersedia'),
	   ('Yougurt', 'Lainnya', 15000, 'Tidak Tersedia')

SELECT * FROM MENU



--Membuat table TRANSAKSI
CREATE TABLE TRANSAKSI
(
	id INT PRIMARY KEY IDENTITY(1,1),
	tanggal_pembayaran DATE,
	biaya_total INT
)

INSERT INTO TRANSAKSI (tanggal_pembayaran, biaya_total)
VALUES ('2024-01-18', 253000),
	   ('2024-01-19', 198000)


SELECT * FROM TRANSAKSI



--Membuat table TransaksiDetail 
CREATE TABLE TransaksiDetail (
    id_transaksi_detail INT PRIMARY KEY IDENTITY(1,1),
    id_transaksi INT,
    id_menu INT,
	jumlah_pesanan INT,
	FOREIGN KEY (id_transaksi) REFERENCES TRANSAKSI(id),
	FOREIGN KEY (id_menu) REFERENCES MENU(id)
);

INSERT INTO TransaksiDetail (id_transaksi, id_menu, jumlah_pesanan)
VALUES (1, 11, 6),
       (1, 1, 4),  
       (1, 3, 2),  
       (2, 3, 4),  
       (2, 11, 4); 

SELECT * FROM TransaksiDetail



--Menampilkan laporan
SELECT
    TRANSAKSI.tanggal_pembayaran,
    STUFF((SELECT ', ' + MENU.nama + ' x' + CAST(TransaksiDetail.jumlah_pesanan AS VARCHAR)
           FROM TransaksiDetail
           INNER JOIN MENU ON TransaksiDetail.id_menu = MENU.id
           WHERE TransaksiDetail.id_transaksi = TRANSAKSI.id
           FOR XML PATH('')), 1, 2, '') AS nama_menu,
	TRANSAKSI.biaya_total
FROM
    TransaksiDetail
INNER JOIN
    TRANSAKSI ON TransaksiDetail.id_transaksi = TRANSAKSI.id
GROUP BY
    TRANSAKSI.id, TRANSAKSI.tanggal_pembayaran, TRANSAKSI.biaya_total



--Membuat table USERS
CREATE TABLE USERS
(
	id INT PRIMARY KEY IDENTITY(1,1),
	nama VARCHAR(100),
	role VARCHAR(100),
	username VARCHAR(100),
	password VARCHAR(100)
)

INSERT INTO USERS (nama, role, username, password)
VALUES ('Admin', 'Admin', 'admin', 'admin'),
	   ('Wahyudi', 'Staff', 'wahyu123', 'wahyu123'),
	   ('Felicia', 'Staff', 'feli123', 'feli123')


SELECT * FROM USERS