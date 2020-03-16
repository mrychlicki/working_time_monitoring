-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 16 Mar 2020, 10:57
-- Wersja serwera: 10.4.11-MariaDB
-- Wersja PHP: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `db_working_time`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `employee`
--

CREATE TABLE `employee` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) COLLATE utf8_polish_ci NOT NULL,
  `Surname` varchar(100) COLLATE utf8_polish_ci NOT NULL,
  `Card_number` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `employee`
--

INSERT INTO `employee` (`ID`, `Name`, `Surname`, `Card_number`) VALUES
(1, 'Mateusz', 'Rychlicki', 1),
(2, 'Adam', 'Nowak', 2),
(3, 'Jan', 'Kowalski', 20202020);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `time_monitoring`
--

CREATE TABLE `time_monitoring` (
  `FK_ID` int(11) NOT NULL,
  `date` date NOT NULL DEFAULT current_timestamp(),
  `time_start` time NOT NULL DEFAULT current_timestamp(),
  `time_end` time DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `time_monitoring`
--

INSERT INTO `time_monitoring` (`FK_ID`, `date`, `time_start`, `time_end`) VALUES
(1, '2020-03-16', '10:50:44', NULL),
(3, '2020-03-16', '10:52:36', '10:54:18');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`ID`);

--
-- Indeksy dla tabeli `time_monitoring`
--
ALTER TABLE `time_monitoring`
  ADD KEY `FK_ID` (`FK_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `employee`
--
ALTER TABLE `employee`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `time_monitoring`
--
ALTER TABLE `time_monitoring`
  ADD CONSTRAINT `time_monitoring_ibfk_1` FOREIGN KEY (`FK_ID`) REFERENCES `employee` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
