-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: Company
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Applications`
--

DROP TABLE IF EXISTS `Applications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Applications` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `FIO` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PhoneNumber` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `E-mail` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DateOfBirth` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PasportDetails` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Login` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Appointment` int DEFAULT NULL,
  `Approved?` tinyint(1) DEFAULT NULL,
  `Reason` varchar(100) DEFAULT NULL,
  `Visited?` tinyint(1) DEFAULT NULL,
  `TypeApplication` varchar(100) NOT NULL,
  `TheDesiredStartOfTheActionOfTheApplication` date DEFAULT NULL,
  `TheDesiredEndOfTheActionOfTheApplication` date DEFAULT NULL,
  `Note` varchar(100) NOT NULL,
  `Organization` varchar(100) NOT NULL,
  `Photo` blob,
  `PassportScan` blob,
  PRIMARY KEY (`ID`),
  KEY `Users_FK` (`Appointment`),
  CONSTRAINT `Applications_FK` FOREIGN KEY (`Appointment`) REFERENCES `Groups` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Applications`
--

LOCK TABLES `Applications` WRITE;
/*!40000 ALTER TABLE `Applications` DISABLE KEYS */;
INSERT INTO `Applications` VALUES (1,'Шилов Прохор Герасимович','+7 (615) 594-77-66','Prohor156@list.ru','9 октября 1977 года','3036 796488','Prohor156','zDdom}SIhWs?',1,0,'Prisoned',1,'Individual',NULL,NULL,'','',NULL,''),(2,'Кононов Юрин Романович','+7 (784) 673-51-91','YUrin155@gmail.com','8 октября 1971 года','2747 790512','YUrin155','u@m*~ACBCqNQ',2,0,'Nigger',NULL,'Individual',NULL,NULL,'','',NULL,''),(3,'Елисеева Альбина Николаевна','+7 (654) 864-77-46','Aljbina33@lenta.ru','15 февраля 1983 года','5241 213304','Aljbina33','Bu?BHCtwDFin',3,0,'Antiuhov',NULL,'Individual',NULL,NULL,'','',NULL,''),(4,'Шарова Клавдия Макаровна','+7 (822) 525-82-40','Klavdiya113@live.com','22 июля 1980 года','8143 593309','Klavdiya113','FjC#hNIJori}',4,1,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(5,'Сидорова Тамара Григорьевна','+7 (334) 692-79-77','Tamara179@live.com','22 ноября 1995 года','8143 905520','Tamara179','TJxVqMXrbesI',5,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(6,'Петухов Тарас Фадеевич','+7 (376) 220-62-51','Taras24@rambler.ru','5 января 1991 года','1609 171096','Taras24','07m5yspn3K~K',6,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(7,'Родионов Аркадий Власович','+7 (491) 696-17-11','Arkadij123@inbox.ru','11 августа 1993 года','3841 642594','Arkadij123','vk2N7lxX}ck%',7,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(8,'Горшкова Глафира Валентиновна','+7 (553) 343-38-82','Glafira73@outlook.com','25 мая 1978 года','9170 402601','Glafira73','Zz8POQlP}M4~',8,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(9,'Кириллова Гавриила Яковна','+7 (648) 700-43-34','Gavriila68@msn.com','26 апреля 1992 года','9438 379667','Gavriila68','x4K5WthEe8ua',9,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(10,'Овчинников Кузьма Ефимович','+7 (562) 866-15-27','Kuzjma124@yandex.ru','2 августа 1993 года','0766 647226','Kuzjma124','OsByQJ}vYznW',10,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(11,'Беляков Роман Викторович','+7 (595) 196-56-28','Roman89@gmail.com','7 июня 1991 года','2411 478305','Roman89','Xd?xP$2yICcG',11,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(12,'Лыткин Алексей Максимович','+7 (994) 353-29-52','Aleksej43@gmail.com','7 марта 1996 года','2383 259825','Aleksej43','~c%PlTY0?qgl',12,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(13,'Шубина Надежда Викторовна','+7 (736) 488-66-95','Nadezhda137@outlook.com','24 сентября 1981 года','8844 708476','Nadezhda137','QQ~0q~rXHb?p',13,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(14,'Зиновьева Бронислава Викторовна','+7 (778) 565-12-18','Bronislava56@yahoo.com','19 марта 1981 года','6736 319423','Bronislava56','LO}xyC~1S4l6',14,NULL,NULL,NULL,'Individual',NULL,NULL,'','',NULL,''),(15,'Самойлова Таисия Гермоновна','+7 (891) 555-81-44','Taisiya177@lenta.ru','14 ноября 1979 года','5193 897719','Taisiya177','R94YGT3XFjgD',15,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(16,'Ситникова Аделаида Гермоновна','+7 (793) 736-70-31','Adelaida20@hotmail.com','21 января 1979 года','7561 148016','Adelaida20','LCY*{L*fEGYB',15,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(17,'Исаев Лев Юлианович','+7 (675) 593-89-30','Lev131@rambler.ru','5 августа 1994 года','1860 680004','Lev131','~?oj2Lh@S7*T',15,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(18,'Никифоров Даниил Степанович','+7 (384) 358-77-82','Daniil198@bk.ru','13 декабря 1970 года','4557 999958','lzaihtvkdn','L2W#uo7z{EsO',15,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(19,'Титова Людмила Якововна','+7 (221) 729-16-84','Lyudmila123@hotmail.com','21 августа 1976 года','7715 639425','Lyudmila123','@8mk9M?NBAGj',15,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(20,'Абрамова Таисия Дмитриевна','+7 (528) 312-18-20','Taisiya176@hotmail.com','20 ноября 1982 года','7310 893510','Taisiya176','~rIWfsnXA~7C',15,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(21,'Кузьмина Вера Максимовна','+7 (598) 583-53-45','Vera195@list.ru','10 декабря 1989 года','3537 982933','Vera195','B|5v$2r$7luL',15,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(22,'Мартынов Яков Ростиславович','+7 (546) 159-67-33','YAkov196@rambler.ru','5 декабря 1976 года','1793 986063','YAkov196','$6s5bggKP7aw',16,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(23,'Евсеева Нина Павловна','+7 (833) 521-31-50','Nina145@msn.com','26 сентября 1994 года','9323 745717','Nina145','Uxy6RtBXIcpT',16,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(24,'Голубев Леонтий Вячеславович','+7 (160) 527-57-41','Leontij161@mail.ru','3 октября 1990 года','1059 822077','Leontij161','KkMY8yKw@oCa',16,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(25,'Карпова Серафима Михаиловна','+7 (459) 930-91-70','Serafima169@yahoo.com','19 ноября 1989 года','7034 858987','Serafima169','gNe3I9}8J3Z@',16,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(26,'Орехов Сергей Емельянович','+7 (669) 603-29-87','Sergej35@inbox.ru','11 февраля 1972 года','3844 223682','Sergej35','$39vc%ljqN%r',16,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(27,'Исаев Георгий Павлович','+7 (678) 516-36-86','Georgij121@inbox.ru','11 августа 1987 года','4076 629809','Georgij121','bbx5H}f*BC?w',16,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(28,'Богданов Елизар Артемович','+7 (165) 768-30-97','Elizar30@yandex.ru','2 февраля 1978 года','0573 198559','Elizar30','wJs1~r3RS~dr',16,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(29,'Тихонова Лана Семеновна','+7 (478) 467-75-15','Lana117@outlook.com','24 июля 1990 года','8761 609740','Lana117','mFoG$jcS3c4~',16,NULL,NULL,NULL,'Groups',NULL,NULL,'','',NULL,''),(30,'Степанова Радинка Власовна','+7 (613) 272-60-62','Radinka100@yandex.ru','18 октября 1986 года','0208 530509','Vlas86','b3uWS6#Thuvq',17,0,'Gey',0,'Individual',NULL,NULL,'','',NULL,'');
/*!40000 ALTER TABLE `Applications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Appointments`
--

DROP TABLE IF EXISTS `Appointments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Appointments` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `DateOfVisit` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ToWhom(ID)` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `Appointments_FK` (`ToWhom(ID)`),
  CONSTRAINT `Appointments_FK` FOREIGN KEY (`ToWhom(ID)`) REFERENCES `Employes` (`EmployeeCode`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Appointments`
--

LOCK TABLES `Appointments` WRITE;
/*!40000 ALTER TABLE `Appointments` DISABLE KEYS */;
INSERT INTO `Appointments` VALUES (1,'24/04/2023_',9788737),(2,'24/04/2023_',9736379),(3,'25/04/2023_',9367788),(4,'25/04/2023_',9788737),(5,'25/04/2023_',9736379),(6,'26/04/2023_',9367788),(7,'26/04/2023_',9788737),(8,'26/04/2023_',9736379),(9,'27/04/2023_',9367788),(10,'27/04/2023_',9788737),(11,'27/04/2023_',9736379),(12,'28/04/2023_',9367788),(13,'28/04/2023_',9788737),(14,'28/04/2023_',9736379),(17,'24/04/2023_',9367788),(18,'24/04/2023_',9367788);
/*!40000 ALTER TABLE `Appointments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Departaments`
--

DROP TABLE IF EXISTS `Departaments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Departaments` (
  `ID` int NOT NULL,
  `Departament` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Departaments`
--

LOCK TABLES `Departaments` WRITE;
/*!40000 ALTER TABLE `Departaments` DISABLE KEYS */;
INSERT INTO `Departaments` VALUES (0,'Производство'),(1,'Сбыт'),(2,'Администрация'),(3,'Служба безопасности'),(4,'Планирование'),(5,'Общий отдел'),(6,'Охрана'),(7,'Охрана');
/*!40000 ALTER TABLE `Departaments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Employes`
--

DROP TABLE IF EXISTS `Employes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Employes` (
  `EmployeeCode` int NOT NULL,
  `Departament` int NOT NULL,
  `FIO` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`EmployeeCode`),
  KEY `Employes_FK` (`Departament`),
  CONSTRAINT `Employes_FK` FOREIGN KEY (`Departament`) REFERENCES `Departaments` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Employes`
--

LOCK TABLES `Employes` WRITE;
/*!40000 ALTER TABLE `Employes` DISABLE KEYS */;
INSERT INTO `Employes` VALUES (9362832,3,'Архипов Тимофей Васильевич'),(9367788,0,'Фомичева Авдотья Трофимовна'),(9404040,6,'Чернов Всеволод Наумович'),(9404041,7,'Марков Юрий Романович'),(9736379,2,'Носкова Наталия Прохоровна'),(9737848,4,'Орехова Вероника Артемовна'),(9768239,5,'Савельев Павел Степанович'),(9788737,1,'Гаврилова Римма Ефимовна');
/*!40000 ALTER TABLE `Employes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Groups`
--

DROP TABLE IF EXISTS `Groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Groups` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Appointment` int DEFAULT NULL,
  `GroupNumber` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Groups_FK` (`Appointment`),
  CONSTRAINT `Groups_FK` FOREIGN KEY (`Appointment`) REFERENCES `Appointments` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Groups`
--

LOCK TABLES `Groups` WRITE;
/*!40000 ALTER TABLE `Groups` DISABLE KEYS */;
INSERT INTO `Groups` VALUES (1,1,'-'),(2,2,'-'),(3,3,'-'),(4,4,'-'),(5,5,'-'),(6,6,'-'),(7,7,'-'),(8,8,'-'),(9,9,'-'),(10,10,'-'),(11,11,'-'),(12,12,'-'),(13,13,'-'),(14,14,'-'),(15,18,'ГР_1'),(16,18,'ГР_2'),(17,18,'-');
/*!40000 ALTER TABLE `Groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'Company'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-09 17:02:41
