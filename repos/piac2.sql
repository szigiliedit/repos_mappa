-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Nov 22. 17:56
-- Kiszolgáló verziója: 10.4.25-MariaDB
-- PHP verzió: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `piac2`
--
CREATE DATABASE IF NOT EXISTS `piac2` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `piac2`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `gyumolcs`
--

CREATE TABLE `gyumolcs` (
  `Id` int(11) NOT NULL,
  `Nev` text DEFAULT NULL,
  `Ar` int(11) NOT NULL,
  `Minoseg` tinyint(3) UNSIGNED NOT NULL,
  `KepUtvonala` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `gyumolcs`
--

INSERT INTO `gyumolcs` (`Id`, `Nev`, `Ar`, `Minoseg`, `KepUtvonala`) VALUES
(1, 'Piros alma', 860, 1, 'img/pirosalma.jpg'),
(2, 'Vilmos körte', 1450, 2, 'img/vilmoskorte.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20221122152447_Initial', '5.0.17');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `gyumolcs`
--
ALTER TABLE `gyumolcs`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `gyumolcs`
--
ALTER TABLE `gyumolcs`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
