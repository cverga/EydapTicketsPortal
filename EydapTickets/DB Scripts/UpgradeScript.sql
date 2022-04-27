ALTER TABLE Tasks ADD SectorId int;
ALTER TABLE Tasks ADD DepartmentId int;


/* GetUserData */
USE [TT_db]
GO

/****** Object:  StoredProcedure [dbo].[GetUserData]    Script Date: 7/13/2016 6:46:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserData]
   @UserId INT,
   @RoleId INT OUTPUT,
   @SectorId INT OUTPUT,
   @DepartmentId INT OUTPUT
AS
BEGIN
   SELECT @RoleId  = RoleId, @SectorId = SectorId, @DepartmentId= DepartmentId
   FROM Users 
   WHERE UserId = @UserId
END
GO


/* Insert task */


USE [TT_db]
GO

/****** Object:  StoredProcedure [dbo].[InsertTask]    Script Date: 7/13/2016 6:45:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[InsertTask]

-- Add the parameters for the stored procedure here

@TaskId uniqueidentifier,

@Comments VARCHAR(500),

@State VARCHAR(50),

@TaskTypeId int,

@Incident_Id uniqueidentifier,

@User_id int

AS

BEGIN

-- SET NOCOUNT ON added to prevent extra result sets from

-- interfering with SELECT statements.

SET NOCOUNT ON;

DECLARE @UserRole INT; 
DECLARE @UserSectorId INT; 
DECLARE @UserDeptId INT; 

EXEC GetUserData @User_id, @RoleId = @UserRole OUTPUT, @SectorId = @UserSectorId OUTPUT, @DepartmentId = @UserDeptId OUTPUT;

insert into Tasks (Task_Id, Task_Description, Comments, State, TaskTypeId, Incident_Id, SectorId, DepartmentId) 
VALUES(@TaskId, dbo.getTaskDescription(@TaskTypeId), @Comments, @State,@TaskTypeId, @Incident_Id, @UserSectorId, @UserDeptId)

-- Insert statements for procedure here

END


GO


/* GetTasks */
USE [TT_db]
GO

/****** Object:  StoredProcedure [dbo].[GetTasks]    Script Date: 7/13/2016 6:59:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTasks]
	-- Add the parameters for the stored procedure here
	@Incident_Id uniqueidentifier,
	@User_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @UserRole INT; 
	DECLARE @UserSectorId INT; 
	DECLARE @UserDeptId INT; 

	EXEC GetUserData @User_id, @RoleId = @UserRole OUTPUT, @SectorId = @UserSectorId OUTPUT, @DepartmentId = @UserDeptId OUTPUT;
	
	-- Admin, SuperViewer
	IF @UserRole = 1 OR @UserRole = 5
		BEGIN

			SELECT	Task_Id,
					Task_Description,
					Comments,
					State,
					TaskTypeId,
					Incident_Id from Tasks 
			where Incident_Id = @Incident_Id

		END
	--Sector viewer
	ELSE IF @UserRole = 4
		BEGIN

			SELECT	Task_Id,
					Task_Description,
					Comments,
					State,
					TaskTypeId,
					Incident_Id from Tasks 
			where Incident_Id = @Incident_Id and SectorId = @UserSectorId

		END
		--router, Data entry, viewer, 
	ELSE IF @UserRole = 2 OR @UserRole = 3 OR @UserRole = 6
		BEGIN

			SELECT	Task_Id,
					Task_Description,
					Comments,
					State,
					TaskTypeId,
					Incident_Id from Tasks 
			where Incident_Id = @Incident_Id and SectorId = @UserSectorId and DepartmentId = @UserDeptId

		END

    -- Insert statements for procedure here
	
END

GO


--20 July 2016

USE [TT_db]
GO

/****** Object:  StoredProcedure [dbo].[GetTanks]    Script Date: 7/20/2016 9:26:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetTanks]
	@UserId int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @UserRole INT; 
	DECLARE @UserSectorId INT; 
	DECLARE @UserDeptId INT; 

	EXEC GetUserData @UserId, @RoleId = @UserRole OUTPUT, @SectorId = @UserSectorId OUTPUT, @DepartmentId = @UserDeptId OUTPUT;

    -- Insert statements for procedure here
	SELECT DexameniID, CONCAT (DexameniName, ' (', ScadaCode,')',' [', Perioxi, ', ', Address,']')  from Dexamenes where SectorId = @UserSectorId
END

GO


