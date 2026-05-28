-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Máj 28. 11:12
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `viragbolt`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aruk`
--

CREATE TABLE `aruk` (
  `id` int(11) NOT NULL,
  `nev` text NOT NULL,
  `kategoriaId` int(11) DEFAULT NULL,
  `leiras` text DEFAULT NULL,
  `keszlet` int(11) DEFAULT NULL,
  `ar` int(11) DEFAULT NULL,
  `kepUrl` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kategoriak`
--

CREATE TABLE `kategoriak` (
  `id` int(11) NOT NULL,
  `nev` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `aruk`
--
ALTER TABLE `aruk`
  ADD PRIMARY KEY (`id`),
  ADD KEY `kategoriaId` (`kategoriaId`);

--
-- A tábla indexei `kategoriak`
--
ALTER TABLE `kategoriak`
  ADD PRIMARY KEY (`id`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `aruk`
--
ALTER TABLE `aruk`
  ADD CONSTRAINT `aruk_ibfk_1` FOREIGN KEY (`kategoriaId`) REFERENCES `kategoriak` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
