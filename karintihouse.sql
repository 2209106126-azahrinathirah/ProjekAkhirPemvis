-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 17, 2024 at 07:54 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `karintihouse`
--

-- --------------------------------------------------------

--
-- Table structure for table `akun`
--

CREATE TABLE `akun` (
  `username` varchar(10) NOT NULL,
  `password` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `akun`
--

INSERT INTO `akun` (`username`, `password`) VALUES
('andi21', '121'),
('arin26', '126'),
('erika17', '117'),
('muftia30', '130'),
('zahrina51', '120');

-- --------------------------------------------------------

--
-- Table structure for table `kamar`
--

CREATE TABLE `kamar` (
  `no_kamar` varchar(5) NOT NULL,
  `lantai` varchar(10) NOT NULL,
  `tipe_kamar` varchar(255) NOT NULL,
  `harga` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `kamar`
--

INSERT INTO `kamar` (`no_kamar`, `lantai`, `tipe_kamar`, `harga`) VALUES
('01', 'Lantai 1', 'Tipe A', 2500000),
('02', 'Lantai 1', 'Tipe B', 2000000),
('03', 'Lantai 1', 'Tipe C', 1500000),
('04', 'Lantai 2', 'Tipe A', 2500000),
('05', 'Lantai 2', 'Tipe B', 2000000),
('06', 'Lantai 2', 'Tipe C', 1500000);

-- --------------------------------------------------------

--
-- Table structure for table `keluhan`
--

CREATE TABLE `keluhan` (
  `id_keluhan` int(5) NOT NULL,
  `no_kamar` varchar(5) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `jenis_keluhan` varchar(50) NOT NULL,
  `keterangan` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `keluhan`
--

INSERT INTO `keluhan` (`id_keluhan`, `no_kamar`, `nama`, `jenis_keluhan`, `keterangan`) VALUES
(9, '02', 'christy', 'Keamanan', 'laptop hilang'),
(10, '04', 'Tia', 'Kebersihan', 'kotor'),
(14, '01', 'Arin', 'Wifi Error', 'gangguan'),
(17, '03', 'Zahrina', 'Keamanan', 'uang hilang');

-- --------------------------------------------------------

--
-- Table structure for table `pembayaran`
--

CREATE TABLE `pembayaran` (
  `id_pembayaran` varchar(10) NOT NULL,
  `id_transaksi` varchar(3) NOT NULL,
  `no_kamar` varchar(10) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `lama_sewa` varchar(20) NOT NULL,
  `total` int(15) NOT NULL,
  `metode_bayar` varchar(50) NOT NULL,
  `tgl_bayar` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pembayaran`
--

INSERT INTO `pembayaran` (`id_pembayaran`, `id_transaksi`, `no_kamar`, `nama`, `lama_sewa`, `total`, `metode_bayar`, `tgl_bayar`) VALUES
('1', '1', '02', 'christy', '2', 4000000, 'Transfer', '2024-05-08'),
('2', '2', '04', 'Tia', '3', 7500000, 'Tunai', '2024-05-17'),
('3', '3', '06', 'Arin', '4', 6000000, 'Transfer', '2024-05-18');

-- --------------------------------------------------------

--
-- Table structure for table `penyewa`
--

CREATE TABLE `penyewa` (
  `id` int(11) NOT NULL,
  `username` varchar(10) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `no_hp` varchar(20) NOT NULL,
  `jenis_kelamin` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `penyewa`
--

INSERT INTO `penyewa` (`id`, `username`, `nama`, `no_hp`, `jenis_kelamin`) VALUES
(117, 'erika17', 'christy', '08364647489', 'Perempuan'),
(120, 'zahrina51', 'Zahrina', '078282828', 'Perempuan'),
(126, 'arin26', 'Arin', '08363829292', 'Perempuan'),
(130, 'muftia30', 'Tia', '0823456789', 'Perempuan');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

CREATE TABLE `transaksi` (
  `id_transaksi` varchar(3) NOT NULL,
  `id` int(11) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `no_kamar` varchar(10) NOT NULL,
  `lama_sewa` varchar(20) NOT NULL,
  `total` int(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`id_transaksi`, `id`, `nama`, `no_kamar`, `lama_sewa`, `total`) VALUES
('1', 117, 'christy', '02', '1', 2000000),
('2', 130, 'Tia', '04', '2', 5000000),
('3', 126, 'Arin', '06', '4', 6000000),
('5', 120, 'Zahrina', '05', '2', 4000000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `akun`
--
ALTER TABLE `akun`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `kamar`
--
ALTER TABLE `kamar`
  ADD PRIMARY KEY (`no_kamar`);

--
-- Indexes for table `keluhan`
--
ALTER TABLE `keluhan`
  ADD PRIMARY KEY (`id_keluhan`);

--
-- Indexes for table `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD PRIMARY KEY (`id_pembayaran`);

--
-- Indexes for table `penyewa`
--
ALTER TABLE `penyewa`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id_transaksi`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `keluhan`
--
ALTER TABLE `keluhan`
  MODIFY `id_keluhan` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `penyewa`
--
ALTER TABLE `penyewa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1346;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
