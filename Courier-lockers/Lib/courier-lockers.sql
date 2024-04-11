/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 80200 (8.2.0)
 Source Host           : localhost:3306
 Source Schema         : courier-lockers

 Target Server Type    : MySQL
 Target Server Version : 80200 (8.2.0)
 File Encoding         : 65001

 Date: 11/04/2024 10:12:16
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for edpmain
-- ----------------------------
DROP TABLE IF EXISTS `edpmain`;
CREATE TABLE `edpmain`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EDPId` int NULL DEFAULT NULL,
  `EDPName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `EDPList` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of edpmain
-- ----------------------------
INSERT INTO `edpmain` VALUES (1, 1, '1', '1');
INSERT INTO `edpmain` VALUES (2, 2, '2', '2');

SET FOREIGN_KEY_CHECKS = 1;
