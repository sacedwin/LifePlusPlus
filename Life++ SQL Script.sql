USE [master]
GO
/****** Object:  Database [fyp1]    Script Date: 7/27/2017 10:15:56 PM ******/
CREATE DATABASE [fyp1]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fyp1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [fyp1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [fyp1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [fyp1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [fyp1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [fyp1] SET ARITHABORT OFF 
GO
ALTER DATABASE [fyp1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [fyp1] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [fyp1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [fyp1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [fyp1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [fyp1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [fyp1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [fyp1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [fyp1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [fyp1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [fyp1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [fyp1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [fyp1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [fyp1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [fyp1] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [fyp1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [fyp1] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [fyp1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [fyp1] SET RECOVERY FULL 
GO
ALTER DATABASE [fyp1] SET  MULTI_USER 
GO
ALTER DATABASE [fyp1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [fyp1] SET DB_CHAINING OFF 
GO
USE [fyp1]
GO
/****** Object:  Table [dbo].[administrator]    Script Date: 7/27/2017 10:15:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[administrator](
	[aid] [int] IDENTITY(1,1) NOT NULL,
	[adminID]  AS ('Admin'+right(CONVERT([varchar](7),[aid]),(100))) PERSISTED NOT NULL,
	[email] [varchar](40) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[address] [varchar](50) NOT NULL,
	[phone] [int] NOT NULL,
	[status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[adminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BloodPlateletRequestEstab]    Script Date: 7/27/2017 10:15:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BloodPlateletRequestEstab](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bplEstabRequestID]  AS ('bper'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[unitsRequired] [int] NOT NULL,
	[unitsMatched] [int] NOT NULL,
	[establishmentID] [varchar](11) NOT NULL,
	[bloodGroup] [varchar](4) NOT NULL,
	[bloodOrPlatelet] [varchar](10) NOT NULL,
	[status] [varchar](12) NOT NULL,
	[requestDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bplEstabRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BloodPlateletRequestUser]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BloodPlateletRequestUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bplUserRequestID]  AS ('bpur'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[unitsRequird] [int] NOT NULL,
	[unitsMatched] [int] NOT NULL,
	[establishmentID] [varchar](11) NOT NULL,
	[requestorID] [varchar](11) NOT NULL,
	[bloodGroup] [varchar](4) NOT NULL,
	[bloodOrPlatelet] [varchar](10) NOT NULL,
	[status] [varchar](12) NOT NULL,
	[requestDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bplUserRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BplTransactionEstabToEstab]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BplTransactionEstabToEstab](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bplEstabTrasactionID]  AS ('bptee'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[bpMatchEstabID] [varchar](12) NOT NULL,
	[unitsPossible] [int] NULL,
	[status] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bplEstabTrasactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BplTransactionEstabToUser]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BplTransactionEstabToUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bplEstabTrasactionID]  AS ('bpteu'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[bpMatchEstabUserID] [varchar](12) NOT NULL,
	[unitsPossible] [int] NULL,
	[status] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bplEstabTrasactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BplTransactionUserToEstab]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BplTransactionUserToEstab](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bplUserToEstabTrasactionID]  AS ('butet'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[bpMatchUsrEstID] [varchar](12) NOT NULL,
	[unitsPossible] [int] NULL,
	[status] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bplUserToEstabTrasactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BplTransactionUserToUser]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BplTransactionUserToUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bplUserTrasactionID]  AS ('bputr'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[bpMatchUsrUsr] [varchar](12) NOT NULL,
	[status] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bplUserTrasactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BPMatchEstabToEstab]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BPMatchEstabToEstab](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bpMatchEstabID]  AS ('bpmee'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[bplEstabRequestID] [varchar](11) NOT NULL,
	[matchID] [varchar](11) NOT NULL,
	[status] [varchar](12) NOT NULL,
	[distance] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[bpMatchEstabID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BPMatchEstabToUser]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BPMatchEstabToUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bpMatchEstabUserID]  AS ('bpmeu'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[bplEstabRequestID] [varchar](11) NOT NULL,
	[matchID] [varchar](11) NOT NULL,
	[status] [varchar](12) NOT NULL,
	[distance] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[bpMatchEstabUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BPMatchUserToEstab]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BPMatchUserToEstab](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bpMatchUsrEstID]  AS ('bpmue'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[bplUserRequestID] [varchar](11) NOT NULL,
	[matchID] [varchar](11) NOT NULL,
	[status] [varchar](12) NOT NULL,
	[distance] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[bpMatchUsrEstID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BPMatchUserToUser]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BPMatchUserToUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bpMatchUsrUsr]  AS ('bpmuu'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[bplUserRequestID] [varchar](11) NOT NULL,
	[matchID] [varchar](11) NOT NULL,
	[status] [varchar](12) NOT NULL,
	[distance] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[bpMatchUsrUsr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[chat]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[message] [varchar](500) NOT NULL,
	[sentby] [varchar](15) NOT NULL,
	[time] [datetime] NOT NULL,
	[status] [varchar](20) NOT NULL
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[deceasedDonor]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[deceasedDonor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deceasedOrganID]  AS ('dcdnr'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[establishmentID] [varchar](11) NOT NULL,
	[bloodGroup] [varchar](4) NOT NULL,
	[DOB] [date] NOT NULL,
	[height] [int] NOT NULL,
	[weight] [int] NOT NULL,
	[deathDate] [datetime] NOT NULL,
	[organType] [varchar](20) NOT NULL,
	[comments] [varchar](200) NULL,
	[hospitalPatientNumber] [varchar](10) NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[deceasedOrganID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[establishment]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[establishment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[establishmentID]  AS ('estb'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[email] [varchar](40) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[type] [varchar](30) NOT NULL,
	[phone] [int] NOT NULL,
	[address] [varchar](50) NOT NULL,
	[adminID] [varchar](12) NOT NULL,
	[tempEstablishmentID] [varchar](12) NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[establishmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[feedbackID]  AS ('Feedback'+right(CONVERT([varchar](7),[Id]),(100))) PERSISTED,
	[name] [varchar](30) NOT NULL,
	[email] [varchar](40) NOT NULL,
	[subject] [varchar](100) NOT NULL,
	[question] [varchar](200) NOT NULL,
	[answer] [varchar](200) NULL,
	[status] [varchar](12) NOT NULL,
	[answerby] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ForumEstablishment]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForumEstablishment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[forumID]  AS ('ForumE'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[title] [varchar](200) NOT NULL,
	[message] [varchar](500) NOT NULL,
	[date] [date] NOT NULL,
	[status] [varchar](20) NOT NULL,
	[establishmentID] [varchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[forumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ForumEstCommentbyEst]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForumEstCommentbyEst](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[forumcommentID]  AS ('ForumEE'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[forumID] [varchar](13) NOT NULL,
	[comments] [varchar](200) NOT NULL,
	[commentby] [varchar](11) NOT NULL,
	[date] [datetime] NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[forumcommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ForumEstCommentbyUser]    Script Date: 7/27/2017 10:15:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForumEstCommentbyUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[forumcommentID]  AS ('ForumEU'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[forumID] [varchar](13) NOT NULL,
	[comments] [varchar](200) NOT NULL,
	[commentby] [varchar](11) NOT NULL,
	[date] [datetime] NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[forumcommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ForumUser]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForumUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[forumID]  AS ('ForumU'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[title] [varchar](200) NOT NULL,
	[message] [varchar](500) NOT NULL,
	[date] [date] NOT NULL,
	[status] [varchar](20) NOT NULL,
	[UserID] [varchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[forumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ForumUserCommentbyEst]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForumUserCommentbyEst](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[forumcommentID]  AS ('ForumUE'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[forumID] [varchar](13) NOT NULL,
	[comments] [varchar](200) NOT NULL,
	[commentby] [varchar](11) NOT NULL,
	[date] [datetime] NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[forumcommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ForumUserCommentbyUser]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForumUserCommentbyUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[forumcommentID]  AS ('ForumUU'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[forumID] [varchar](13) NOT NULL,
	[comments] [varchar](200) NOT NULL,
	[commentby] [varchar](11) NOT NULL,
	[date] [datetime] NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[forumcommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IndividualChat]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IndividualChat](
	[sender] [varchar](11) NOT NULL,
	[receiver] [varchar](11) NOT NULL,
	[time] [datetime] NOT NULL,
	[message] [varchar](501) NOT NULL
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LastDonationDate]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LastDonationDate](
	[dId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [varchar](11) NOT NULL,
	[donationDate] [date] NOT NULL,
	[type] [varchar](10) NOT NULL,
	[status] [varchar](20) NULL
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[liveDonor]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[liveDonor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ldonorID]  AS ('ldnr'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[userID] [varchar](11) NOT NULL,
	[organType] [varchar](30) NOT NULL,
	[comments] [varchar](200) NULL,
	[status] [varchar](20) NULL,
	[doctorName] [varchar](20) NOT NULL,
	[doctorNumber] [int] NOT NULL,
	[doctorAddress] [varchar](100) NOT NULL,
	[doctorEmail] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ldonorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[organMatchingDeceased]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[organMatchingDeceased](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deceasedOrganMatch]  AS ('omdc'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[deceasedOrganID] [varchar](12) NOT NULL,
	[OrganWlID] [varchar](11) NOT NULL,
	[matchScore] [int] NOT NULL,
	[comments] [varchar](200) NULL,
	[status] [varchar](20) NOT NULL,
	[distance] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[deceasedOrganMatch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[organMatchingLive]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[organMatchingLive](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[liveOrganMatch]  AS ('omld'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[ldonorID] [varchar](11) NOT NULL,
	[OrganWlID] [varchar](11) NOT NULL,
	[matchScore] [int] NOT NULL,
	[comments] [varchar](200) NULL,
	[status] [varchar](20) NOT NULL,
	[distance] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[liveOrganMatch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[organReceiverWaiting]    Script Date: 7/27/2017 10:15:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[organReceiverWaiting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrganWlID]  AS ('orwl'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[establishmentID] [varchar](11) NOT NULL,
	[bloodGroup] [varchar](4) NOT NULL,
	[DOB] [date] NOT NULL,
	[height] [int] NOT NULL,
	[weight] [int] NOT NULL,
	[addedOn] [date] NOT NULL,
	[organRequired] [varchar](20) NOT NULL,
	[comments] [varchar](200) NULL,
	[urgency] [int] NOT NULL,
	[hospitalPatientNumber] [varchar](10) NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrganWlID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tempEstablishment]    Script Date: 7/27/2017 10:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tempEstablishment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tempEstablishmentID]  AS ('testb'+right(CONVERT([varchar](7),[id]),(100))) PERSISTED NOT NULL,
	[email] [varchar](40) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[type] [varchar](30) NOT NULL,
	[phone] [int] NOT NULL,
	[address] [varchar](50) NOT NULL,
	[status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tempEstablishmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/27/2017 10:15:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID]  AS ('User'+right(CONVERT([varchar](7),[Id]),(100))) PERSISTED NOT NULL,
	[email] [varchar](40) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[DOB] [date] NOT NULL,
	[gender] [varchar](10) NOT NULL,
	[rStatus] [char](20) NOT NULL,
	[height] [int] NULL,
	[weight] [int] NULL,
	[bloodType] [varchar](3) NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[phone] [int] NOT NULL,
	[NRICNo] [varchar](20) NOT NULL,
	[emergencyName] [varchar](30) NULL,
	[emergencyPhone] [int] NULL,
	[emergencyRelationship] [varchar](20) NULL,
	[status] [varchar](20) NULL,
	[address] [varchar](250) NOT NULL,
	[zipcode] [int] NOT NULL,
	[nationality] [varchar](40) NOT NULL,
	[profile] [varchar](200) NULL,
	[doneBy] [varchar](30) NULL,
	[medicalStatus] [varchar](20) NULL,
	[mediStatusUpdateBy] [varchar](11) NULL,
	[latitude] [varchar](30) NULL,
	[longitude] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[NRICNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[administrator] ADD  DEFAULT ('Allow') FOR [status]
GO
ALTER TABLE [dbo].[BloodPlateletRequestEstab] ADD  DEFAULT ((0)) FOR [unitsMatched]
GO
ALTER TABLE [dbo].[BloodPlateletRequestEstab] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[BloodPlateletRequestUser] ADD  DEFAULT ((0)) FOR [unitsMatched]
GO
ALTER TABLE [dbo].[BloodPlateletRequestUser] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[BplTransactionEstabToEstab] ADD  DEFAULT ((1)) FOR [unitsPossible]
GO
ALTER TABLE [dbo].[BplTransactionEstabToEstab] ADD  DEFAULT ('accepted') FOR [status]
GO
ALTER TABLE [dbo].[BplTransactionEstabToUser] ADD  DEFAULT ((1)) FOR [unitsPossible]
GO
ALTER TABLE [dbo].[BplTransactionEstabToUser] ADD  DEFAULT ('accepted') FOR [status]
GO
ALTER TABLE [dbo].[BplTransactionUserToEstab] ADD  DEFAULT ((1)) FOR [unitsPossible]
GO
ALTER TABLE [dbo].[BplTransactionUserToEstab] ADD  DEFAULT ('accepted') FOR [status]
GO
ALTER TABLE [dbo].[BplTransactionUserToUser] ADD  DEFAULT ('accepted') FOR [status]
GO
ALTER TABLE [dbo].[BPMatchEstabToEstab] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[BPMatchEstabToUser] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[BPMatchUserToEstab] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[BPMatchUserToUser] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[chat] ADD  DEFAULT ('allow') FOR [status]
GO
ALTER TABLE [dbo].[deceasedDonor] ADD  DEFAULT ('not allotted') FOR [status]
GO
ALTER TABLE [dbo].[establishment] ADD  DEFAULT ('active') FOR [status]
GO
ALTER TABLE [dbo].[feedback] ADD  DEFAULT ('unanswered') FOR [status]
GO
ALTER TABLE [dbo].[ForumEstablishment] ADD  DEFAULT ('allow') FOR [status]
GO
ALTER TABLE [dbo].[ForumEstCommentbyEst] ADD  DEFAULT ('allow') FOR [status]
GO
ALTER TABLE [dbo].[ForumEstCommentbyUser] ADD  DEFAULT ('allow') FOR [status]
GO
ALTER TABLE [dbo].[ForumUser] ADD  DEFAULT ('allow') FOR [status]
GO
ALTER TABLE [dbo].[ForumUserCommentbyEst] ADD  DEFAULT ('allow') FOR [status]
GO
ALTER TABLE [dbo].[ForumUserCommentbyUser] ADD  DEFAULT ('allow') FOR [status]
GO
ALTER TABLE [dbo].[liveDonor] ADD  DEFAULT ('not allotted') FOR [status]
GO
ALTER TABLE [dbo].[organMatchingDeceased] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[organMatchingLive] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[organReceiverWaiting] ADD  DEFAULT ('waiting') FOR [status]
GO
ALTER TABLE [dbo].[tempEstablishment] ADD  DEFAULT ('pending') FOR [status]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('Allow') FOR [status]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('can donate') FOR [medicalStatus]
GO
ALTER TABLE [dbo].[BloodPlateletRequestEstab]  WITH CHECK ADD FOREIGN KEY([establishmentID])
REFERENCES [dbo].[establishment] ([establishmentID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BloodPlateletRequestUser]  WITH CHECK ADD FOREIGN KEY([establishmentID])
REFERENCES [dbo].[establishment] ([establishmentID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BloodPlateletRequestUser]  WITH CHECK ADD FOREIGN KEY([requestorID])
REFERENCES [dbo].[Users] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BplTransactionEstabToEstab]  WITH CHECK ADD FOREIGN KEY([bpMatchEstabID])
REFERENCES [dbo].[BPMatchEstabToEstab] ([bpMatchEstabID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BplTransactionEstabToUser]  WITH CHECK ADD FOREIGN KEY([bpMatchEstabUserID])
REFERENCES [dbo].[BPMatchEstabToUser] ([bpMatchEstabUserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BplTransactionUserToEstab]  WITH CHECK ADD FOREIGN KEY([bpMatchUsrEstID])
REFERENCES [dbo].[BPMatchUserToEstab] ([bpMatchUsrEstID])
GO
ALTER TABLE [dbo].[BplTransactionUserToUser]  WITH CHECK ADD FOREIGN KEY([bpMatchUsrUsr])
REFERENCES [dbo].[BPMatchUserToUser] ([bpMatchUsrUsr])
GO
ALTER TABLE [dbo].[BPMatchEstabToEstab]  WITH CHECK ADD FOREIGN KEY([bplEstabRequestID])
REFERENCES [dbo].[BloodPlateletRequestEstab] ([bplEstabRequestID])
GO
ALTER TABLE [dbo].[BPMatchEstabToEstab]  WITH CHECK ADD FOREIGN KEY([matchID])
REFERENCES [dbo].[establishment] ([establishmentID])
GO
ALTER TABLE [dbo].[BPMatchEstabToUser]  WITH CHECK ADD FOREIGN KEY([bplEstabRequestID])
REFERENCES [dbo].[BloodPlateletRequestEstab] ([bplEstabRequestID])
GO
ALTER TABLE [dbo].[BPMatchEstabToUser]  WITH CHECK ADD FOREIGN KEY([matchID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[BPMatchUserToEstab]  WITH CHECK ADD FOREIGN KEY([bplUserRequestID])
REFERENCES [dbo].[BloodPlateletRequestUser] ([bplUserRequestID])
GO
ALTER TABLE [dbo].[BPMatchUserToEstab]  WITH CHECK ADD FOREIGN KEY([matchID])
REFERENCES [dbo].[establishment] ([establishmentID])
GO
ALTER TABLE [dbo].[BPMatchUserToUser]  WITH CHECK ADD FOREIGN KEY([bplUserRequestID])
REFERENCES [dbo].[BloodPlateletRequestUser] ([bplUserRequestID])
GO
ALTER TABLE [dbo].[BPMatchUserToUser]  WITH CHECK ADD FOREIGN KEY([matchID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[deceasedDonor]  WITH CHECK ADD FOREIGN KEY([establishmentID])
REFERENCES [dbo].[establishment] ([establishmentID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[establishment]  WITH CHECK ADD FOREIGN KEY([adminID])
REFERENCES [dbo].[administrator] ([adminID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[establishment]  WITH CHECK ADD FOREIGN KEY([tempEstablishmentID])
REFERENCES [dbo].[tempEstablishment] ([tempEstablishmentID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ForumEstablishment]  WITH CHECK ADD FOREIGN KEY([establishmentID])
REFERENCES [dbo].[establishment] ([establishmentID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ForumEstCommentbyEst]  WITH CHECK ADD FOREIGN KEY([commentby])
REFERENCES [dbo].[establishment] ([establishmentID])
GO
ALTER TABLE [dbo].[ForumEstCommentbyEst]  WITH CHECK ADD FOREIGN KEY([forumID])
REFERENCES [dbo].[ForumEstablishment] ([forumID])
GO
ALTER TABLE [dbo].[ForumEstCommentbyUser]  WITH CHECK ADD FOREIGN KEY([commentby])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ForumEstCommentbyUser]  WITH CHECK ADD FOREIGN KEY([forumID])
REFERENCES [dbo].[ForumEstablishment] ([forumID])
GO
ALTER TABLE [dbo].[ForumUser]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ForumUserCommentbyEst]  WITH CHECK ADD FOREIGN KEY([commentby])
REFERENCES [dbo].[establishment] ([establishmentID])
GO
ALTER TABLE [dbo].[ForumUserCommentbyEst]  WITH CHECK ADD FOREIGN KEY([forumID])
REFERENCES [dbo].[ForumUser] ([forumID])
GO
ALTER TABLE [dbo].[ForumUserCommentbyUser]  WITH CHECK ADD FOREIGN KEY([commentby])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ForumUserCommentbyUser]  WITH CHECK ADD FOREIGN KEY([forumID])
REFERENCES [dbo].[ForumUser] ([forumID])
GO
ALTER TABLE [dbo].[LastDonationDate]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[liveDonor]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[organMatchingDeceased]  WITH CHECK ADD FOREIGN KEY([deceasedOrganID])
REFERENCES [dbo].[deceasedDonor] ([deceasedOrganID])
GO
ALTER TABLE [dbo].[organMatchingDeceased]  WITH CHECK ADD FOREIGN KEY([OrganWlID])
REFERENCES [dbo].[organReceiverWaiting] ([OrganWlID])
GO
ALTER TABLE [dbo].[organMatchingLive]  WITH CHECK ADD FOREIGN KEY([ldonorID])
REFERENCES [dbo].[liveDonor] ([ldonorID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[organMatchingLive]  WITH CHECK ADD FOREIGN KEY([OrganWlID])
REFERENCES [dbo].[organReceiverWaiting] ([OrganWlID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[organReceiverWaiting]  WITH CHECK ADD FOREIGN KEY([establishmentID])
REFERENCES [dbo].[establishment] ([establishmentID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[administrator]  WITH CHECK ADD CHECK  (([Status]='Inactive' OR [Status]='Active'))
GO
ALTER TABLE [dbo].[BloodPlateletRequestEstab]  WITH CHECK ADD CHECK  (([bloodOrPlatelet]='platelet' OR [bloodOrPlatelet]='blood'))
GO
ALTER TABLE [dbo].[BloodPlateletRequestEstab]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='complete' OR [status]='pending'))
GO
ALTER TABLE [dbo].[BloodPlateletRequestUser]  WITH CHECK ADD CHECK  (([bloodOrPlatelet]='platelet' OR [bloodOrPlatelet]='blood'))
GO
ALTER TABLE [dbo].[BloodPlateletRequestUser]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='complete' OR [status]='pending'))
GO
ALTER TABLE [dbo].[BplTransactionEstabToEstab]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='complete' OR [status]='accepted'))
GO
ALTER TABLE [dbo].[BplTransactionEstabToUser]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='complete' OR [status]='accepted'))
GO
ALTER TABLE [dbo].[BplTransactionUserToEstab]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='complete' OR [status]='accepted'))
GO
ALTER TABLE [dbo].[BplTransactionUserToUser]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='complete' OR [status]='accepted'))
GO
ALTER TABLE [dbo].[BPMatchEstabToEstab]  WITH CHECK ADD CHECK  (([status]='complete' OR [status]='accepted' OR [status]='declined' OR [status]='pending'))
GO
ALTER TABLE [dbo].[BPMatchEstabToUser]  WITH CHECK ADD CHECK  (([status]='complete' OR [status]='accepted' OR [status]='declined' OR [status]='pending'))
GO
ALTER TABLE [dbo].[BPMatchUserToEstab]  WITH CHECK ADD CHECK  (([status]='complete' OR [status]='accepted' OR [status]='declined' OR [status]='pending'))
GO
ALTER TABLE [dbo].[BPMatchUserToUser]  WITH CHECK ADD CHECK  (([status]='complete' OR [status]='accepted' OR [status]='declined' OR [status]='pending'))
GO
ALTER TABLE [dbo].[chat]  WITH CHECK ADD CHECK  (([status]='ban' OR [status]='allow'))
GO
ALTER TABLE [dbo].[establishment]  WITH CHECK ADD CHECK  (([status]='inactive' OR [status]='active'))
GO
ALTER TABLE [dbo].[establishment]  WITH CHECK ADD CHECK  (([type]='Government' OR [type]='NGO' OR [type]='Emergency Responder' OR [type]='Blood Bank' OR [type]='Hospital'))
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD CHECK  (([status]='reported' OR [status]='unanswered' OR [status]='answered'))
GO
ALTER TABLE [dbo].[ForumEstablishment]  WITH CHECK ADD CHECK  (([status]='finished' OR [status]='ban' OR [status]='allow'))
GO
ALTER TABLE [dbo].[ForumEstCommentbyEst]  WITH CHECK ADD CHECK  (([status]='delete' OR [status]='ban' OR [status]='allow'))
GO
ALTER TABLE [dbo].[ForumEstCommentbyUser]  WITH CHECK ADD CHECK  (([status]='delete' OR [status]='ban' OR [status]='allow'))
GO
ALTER TABLE [dbo].[ForumUser]  WITH CHECK ADD CHECK  (([status]='finished' OR [status]='ban' OR [status]='allow'))
GO
ALTER TABLE [dbo].[ForumUserCommentbyEst]  WITH CHECK ADD CHECK  (([status]='delete' OR [status]='ban' OR [status]='allow'))
GO
ALTER TABLE [dbo].[ForumUserCommentbyUser]  WITH CHECK ADD CHECK  (([status]='delete' OR [status]='ban' OR [status]='allow'))
GO
ALTER TABLE [dbo].[LastDonationDate]  WITH CHECK ADD CHECK  (([status]='Not in transaction' OR [status]='In transaction'))
GO
ALTER TABLE [dbo].[LastDonationDate]  WITH CHECK ADD CHECK  (([type]='platelet' OR [type]='blood'))
GO
ALTER TABLE [dbo].[liveDonor]  WITH CHECK ADD CHECK  (([organType]='kidney' OR [organType]='liver'))
GO
ALTER TABLE [dbo].[liveDonor]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='allotted' OR [status]='not allotted'))
GO
ALTER TABLE [dbo].[organMatchingDeceased]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='complete' OR [status]='pending' OR [status]='not possible' OR [status]='current match'))
GO
ALTER TABLE [dbo].[organMatchingLive]  WITH CHECK ADD CHECK  (([status]='cancelled' OR [status]='complete' OR [status]='pending' OR [status]='not possible' OR [status]='current match'))
GO
ALTER TABLE [dbo].[tempEstablishment]  WITH CHECK ADD CHECK  (([status]='dismissed' OR [status]='approved' OR [status]='pending'))
GO
ALTER TABLE [dbo].[tempEstablishment]  WITH CHECK ADD CHECK  (([type]='Government' OR [type]='NGO' OR [type]='Emergency Responder' OR [type]='Blood Bank' OR [type]='Hospital'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([EmergencyRelationship]='null' OR [EmergencyRelationship]='Others' OR [EmergencyRelationship]='Spouse' OR [EmergencyRelationship]='Friend' OR [EmergencyRelationship]='Child' OR [EmergencyRelationship]='Parent/Guardian'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([medicalStatus]='cannot donate' OR [medicalStatus]='can donate'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Status]='Debar' OR [Status]='Allow'))
GO
USE [master]
GO
ALTER DATABASE [fyp1] SET  READ_WRITE 
GO
