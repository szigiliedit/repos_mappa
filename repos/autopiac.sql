-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Nov 22. 19:25
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
-- Adatbázis: `autopiac`
--
CREATE DATABASE IF NOT EXISTS `autopiac` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `autopiac`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalo`
--

CREATE TABLE `felhasznalo` (
  `ID` int(7) NOT NULL,
  `FelhasznaloNeve` varchar(30) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `TeljesNev` varchar(40) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Salt` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Hash` varchar(64) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Email` varchar(45) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Jogusultsag` int(1) NOT NULL,
  `Aktiv` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalo`
--

INSERT INTO `felhasznalo` (`ID`, `FelhasznaloNeve`, `TeljesNev`, `Salt`, `Hash`, `Email`, `Jogusultsag`, `Aktiv`) VALUES
(1, 'a', 'Adminisztrátor', 'dkBczmjgWSy0aujs7sjUppKkICH17L0eYo2XGYUCmOp9Dia1uWrsCDjyZaUxeriL', '9eb55e5fe5a8745da5bb73d2a5babf6888d1dbdb03da9c83f95ff2c08d775c4f', 'kerenyir@kkszki.hu', 9, 1);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `felhasznalo`
--
ALTER TABLE `felhasznalo`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `FelhasznaloNeve` (`FelhasznaloNeve`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `felhasznalo`
--
ALTER TABLE `felhasznalo`
  MODIFY `ID` int(7) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
