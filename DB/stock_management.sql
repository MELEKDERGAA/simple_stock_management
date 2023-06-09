-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 09, 2023 at 05:37 PM
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
-- Database: `stock_management`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`username`, `password`) VALUES
('admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `color`
--

CREATE TABLE `color` (
  `color_name` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `color`
--

INSERT INTO `color` (`color_name`) VALUES
('black'),
('red');

-- --------------------------------------------------------

--
-- Table structure for table `prodcolor`
--

CREATE TABLE `prodcolor` (
  `id_prod` varchar(20) NOT NULL,
  `color_name` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `id_prod` varchar(20) NOT NULL,
  `nom_prod` varchar(50) NOT NULL,
  `categorie` varchar(50) NOT NULL,
  `image_prod` tinyblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`id_prod`, `nom_prod`, `categorie`, `image_prod`) VALUES
('123', 'olfa', 'ezafzaf', 0x53797374656d2e427974655b5d),
('1234', 'semi', 'ezafzaf', 0x53797374656d2e427974655b5d),
('12345', 'melek', 'dezdazd', 0x53797374656d2e427974655b5d);

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE `stock` (
  `id_prod` varchar(20) NOT NULL,
  `quantite` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`id_prod`, `quantite`) VALUES
('123', 30),
('1234', 10),
('12345', 10);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `color`
--
ALTER TABLE `color`
  ADD PRIMARY KEY (`color_name`),
  ADD KEY `color_name` (`color_name`);

--
-- Indexes for table `prodcolor`
--
ALTER TABLE `prodcolor`
  ADD PRIMARY KEY (`id_prod`,`color_name`),
  ADD KEY `id prod` (`id_prod`),
  ADD KEY `color name` (`color_name`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`id_prod`),
  ADD KEY `id_prod` (`id_prod`);

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
  ADD PRIMARY KEY (`id_prod`),
  ADD KEY `id_prod` (`id_prod`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `prodcolor`
--
ALTER TABLE `prodcolor`
  ADD CONSTRAINT `prodcolor_ibfk_1` FOREIGN KEY (`id_prod`) REFERENCES `product` (`id_prod`) ON DELETE CASCADE,
  ADD CONSTRAINT `prodcolor_ibfk_2` FOREIGN KEY (`color_name`) REFERENCES `color` (`color_name`) ON DELETE CASCADE;

--
-- Constraints for table `stock`
--
ALTER TABLE `stock`
  ADD CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`id_prod`) REFERENCES `product` (`id_prod`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
