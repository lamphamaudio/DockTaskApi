using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBE.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "frequency",
                columns: table => new
                {
                    frequencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    frequencyType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    frequencyDetail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    intervalValue = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_frequency", x => x.frequencyId);
                });

            migrationBuilder.CreateTable(
                name: "org",
                columns: table => new
                {
                    orgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orgName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    parentOrgId = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org", x => x.orgId);
                });

            migrationBuilder.CreateTable(
                name: "period",
                columns: table => new
                {
                    periodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    periodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    startDate = table.Column<DateOnly>(type: "date", nullable: false),
                    endDate = table.Column<DateOnly>(type: "date", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_period", x => x.periodId);
                });

            migrationBuilder.CreateTable(
                name: "position",
                columns: table => new
                {
                    positionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    positionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_position", x => x.positionId);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    roleid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdat = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "frequency_detail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    frequencyId = table.Column<int>(type: "int", nullable: false),
                    dayOfWeek = table.Column<int>(type: "int", nullable: true),
                    dayOfMonth = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_frequency_detail", x => x.id);
                    table.ForeignKey(
                        name: "fk_frequency_detail_frequency",
                        column: x => x.frequencyId,
                        principalTable: "frequency",
                        principalColumn: "frequencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unit",
                columns: table => new
                {
                    unitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orgId = table.Column<int>(type: "int", nullable: false),
                    unitName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "official"),
                    unitParent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit", x => x.unitId);
                    table.ForeignKey(
                        name: "fkUnitOrg",
                        column: x => x.orgId,
                        principalTable: "org",
                        principalColumn: "orgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    notificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: true),
                    taskId = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.notificationId);
                });

            migrationBuilder.CreateTable(
                name: "progress",
                columns: table => new
                {
                    progressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    periodId = table.Column<int>(type: "int", nullable: true),
                    percentageComplete = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    updatedBy = table.Column<int>(type: "int", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    fileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    filePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    proposal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_progress", x => x.progressId);
                    table.ForeignKey(
                        name: "fkProgressPeriod",
                        column: x => x.periodId,
                        principalTable: "period",
                        principalColumn: "periodId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "reminder",
                columns: table => new
                {
                    reminderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskid = table.Column<int>(type: "int", nullable: false),
                    periodid = table.Column<int>(type: "int", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    triggertime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    isauto = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    createdby = table.Column<int>(type: "int", nullable: true),
                    createdat = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    isnotified = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    notifiedat = table.Column<DateTime>(type: "datetime", nullable: true),
                    notificationid = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValue: ""),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminder", x => x.reminderid);
                    table.ForeignKey(
                        name: "reminder_ibfk_2",
                        column: x => x.periodid,
                        principalTable: "period",
                        principalColumn: "periodId");
                    table.ForeignKey(
                        name: "reminder_ibfk_4",
                        column: x => x.notificationid,
                        principalTable: "notification",
                        principalColumn: "notificationId");
                });

            migrationBuilder.CreateTable(
                name: "reminderunit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reminderid = table.Column<int>(type: "int", nullable: false),
                    unitid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminderunit", x => x.id);
                    table.ForeignKey(
                        name: "fk_reminder",
                        column: x => x.reminderid,
                        principalTable: "reminder",
                        principalColumn: "reminderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_unit",
                        column: x => x.unitid,
                        principalTable: "unit",
                        principalColumn: "unitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report_review",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    progressId = table.Column<int>(type: "int", nullable: false),
                    reviewer_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reviewed_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__report_r__2ECD6E04C573B4B5", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_ReportReview_Progress",
                        column: x => x.progressId,
                        principalTable: "progress",
                        principalColumn: "progressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reportsummary",
                columns: table => new
                {
                    reportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<int>(type: "int", nullable: true),
                    periodId = table.Column<int>(type: "int", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdBy = table.Column<int>(type: "int", nullable: true),
                    reportFile = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportsummary", x => x.reportId);
                    table.ForeignKey(
                        name: "fkReportPeriod",
                        column: x => x.periodId,
                        principalTable: "period",
                        principalColumn: "periodId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    taskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assignerId = table.Column<int>(type: "int", nullable: true),
                    assigneeId = table.Column<int>(type: "int", nullable: true),
                    orgId = table.Column<int>(type: "int", nullable: true),
                    periodId = table.Column<int>(type: "int", nullable: true),
                    attachedFile = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "pending"),
                    priority = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "medium"),
                    startDate = table.Column<DateOnly>(type: "date", nullable: true),
                    dueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    unitId = table.Column<int>(type: "int", nullable: true),
                    frequencyId = table.Column<int>(type: "int", nullable: true),
                    percentagecomplete = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    parentTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.taskId);
                    table.ForeignKey(
                        name: "fk_taskitem_frequency",
                        column: x => x.frequencyId,
                        principalTable: "frequency",
                        principalColumn: "frequencyId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "taskunitassignment",
                columns: table => new
                {
                    TaskUnitAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskunitassignment", x => x.TaskUnitAssignmentId);
                    table.ForeignKey(
                        name: "taskunitassignment_ibfk_1",
                        column: x => x.TaskId,
                        principalTable: "task",
                        principalColumn: "taskId");
                    table.ForeignKey(
                        name: "taskunitassignment_ibfk_2",
                        column: x => x.UnitId,
                        principalTable: "unit",
                        principalColumn: "unitId");
                });

            migrationBuilder.CreateTable(
                name: "taskassignees",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskassignees", x => new { x.TaskId, x.UserId });
                    table.ForeignKey(
                        name: "taskassignees_ibfk_1",
                        column: x => x.TaskId,
                        principalTable: "task",
                        principalColumn: "taskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unituser",
                columns: table => new
                {
                    unitUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unituser", x => x.unitUserId);
                    table.ForeignKey(
                        name: "fkUnitUserUnit",
                        column: x => x.unitId,
                        principalTable: "unit",
                        principalColumn: "unitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    orgId = table.Column<int>(type: "int", nullable: true),
                    unitId = table.Column<int>(type: "int", nullable: true),
                    userParent = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    refreshtoken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    refreshtokenexpirytime = table.Column<DateTime>(type: "datetime", nullable: true),
                    role = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false, defaultValue: "0"),
                    unitUserId = table.Column<int>(type: "int", nullable: true),
                    positionId = table.Column<int>(type: "int", nullable: true),
                    positionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userId);
                    table.ForeignKey(
                        name: "fk_user_unitUser",
                        column: x => x.unitUserId,
                        principalTable: "unituser",
                        principalColumn: "unitUserId");
                    table.ForeignKey(
                        name: "user_ibfk_1",
                        column: x => x.positionId,
                        principalTable: "position",
                        principalColumn: "positionId");
                    table.ForeignKey(
                        name: "user_ibfk_2",
                        column: x => x.orgId,
                        principalTable: "org",
                        principalColumn: "orgId");
                    table.ForeignKey(
                        name: "user_ibfk_3",
                        column: x => x.unitId,
                        principalTable: "unit",
                        principalColumn: "unitId");
                    table.ForeignKey(
                        name: "user_ibfk_4",
                        column: x => x.userParent,
                        principalTable: "user",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "uploadfile",
                columns: table => new
                {
                    fileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    uploadedBy = table.Column<int>(type: "int", nullable: true),
                    uploadedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uploadfile", x => x.fileId);
                    table.ForeignKey(
                        name: "fkUploadFileUploadedBy",
                        column: x => x.uploadedBy,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "userrole",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    roleid = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrole", x => x.id);
                    table.ForeignKey(
                        name: "fk_userrole_role",
                        column: x => x.roleid,
                        principalTable: "role",
                        principalColumn: "roleid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_userrole_user",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_frequency_detail_frequencyId",
                table: "frequency_detail",
                column: "frequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_notification_taskId",
                table: "notification",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_notification_userId",
                table: "notification",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_progress_periodId",
                table: "progress",
                column: "periodId");

            migrationBuilder.CreateIndex(
                name: "IX_progress_taskId",
                table: "progress",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_progress_updatedBy",
                table: "progress",
                column: "updatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_createdby",
                table: "reminder",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_notificationid",
                table: "reminder",
                column: "notificationid");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_periodid",
                table: "reminder",
                column: "periodid");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_taskid",
                table: "reminder",
                column: "taskid");

            migrationBuilder.CreateIndex(
                name: "IX_reminder_UserId",
                table: "reminder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_reminderunit_reminderid",
                table: "reminderunit",
                column: "reminderid");

            migrationBuilder.CreateIndex(
                name: "IX_reminderunit_unitid",
                table: "reminderunit",
                column: "unitid");

            migrationBuilder.CreateIndex(
                name: "IX_report_review_progressId",
                table: "report_review",
                column: "progressId");

            migrationBuilder.CreateIndex(
                name: "IX_report_review_reviewer_id",
                table: "report_review",
                column: "reviewer_id");

            migrationBuilder.CreateIndex(
                name: "IX_reportsummary_createdBy",
                table: "reportsummary",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_reportsummary_periodId",
                table: "reportsummary",
                column: "periodId");

            migrationBuilder.CreateIndex(
                name: "IX_reportsummary_reportFile",
                table: "reportsummary",
                column: "reportFile");

            migrationBuilder.CreateIndex(
                name: "IX_reportsummary_taskId",
                table: "reportsummary",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_task_assigneeId",
                table: "task",
                column: "assigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_task_frequencyId",
                table: "task",
                column: "frequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_taskassignees_UserId",
                table: "taskassignees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_taskunitassignment_TaskId",
                table: "taskunitassignment",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_taskunitassignment_UnitId",
                table: "taskunitassignment",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_unit_orgId",
                table: "unit",
                column: "orgId");

            migrationBuilder.CreateIndex(
                name: "IX_unituser_unitId",
                table: "unituser",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_unituser_userId",
                table: "unituser",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_uploadfile_uploadedBy",
                table: "uploadfile",
                column: "uploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_user_orgId",
                table: "user",
                column: "orgId");

            migrationBuilder.CreateIndex(
                name: "IX_user_positionId",
                table: "user",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_user_unitId",
                table: "user",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_user_unitUserId",
                table: "user",
                column: "unitUserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_userParent",
                table: "user",
                column: "userParent");

            migrationBuilder.CreateIndex(
                name: "UQ_user_email",
                table: "user",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_user_username",
                table: "user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userrole_roleid",
                table: "userrole",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_userrole_userid",
                table: "userrole",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "fkNotificationTask",
                table: "notification",
                column: "taskId",
                principalTable: "task",
                principalColumn: "taskId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fkNotificationUser",
                table: "notification",
                column: "userId",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fkProgressTask",
                table: "progress",
                column: "taskId",
                principalTable: "task",
                principalColumn: "taskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fkProgressUpdatedBy",
                table: "progress",
                column: "updatedBy",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_reminder_User_UserId",
                table: "reminder",
                column: "UserId",
                principalTable: "user",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "reminder_ibfk_3",
                table: "reminder",
                column: "createdby",
                principalTable: "user",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "reminder_ibfk_1",
                table: "reminder",
                column: "taskid",
                principalTable: "task",
                principalColumn: "taskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportReview_User",
                table: "report_review",
                column: "reviewer_id",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fkReportCreatedBy",
                table: "reportsummary",
                column: "createdBy",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fkReportFile",
                table: "reportsummary",
                column: "reportFile",
                principalTable: "uploadfile",
                principalColumn: "fileId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fkReportTask",
                table: "reportsummary",
                column: "taskId",
                principalTable: "task",
                principalColumn: "taskId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fkTaskAssignee",
                table: "task",
                column: "assigneeId",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "taskassignees_ibfk_2",
                table: "taskassignees",
                column: "UserId",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fkUnitUserUser",
                table: "unituser",
                column: "userId",
                principalTable: "user",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fkUnitUserUser",
                table: "unituser");

            migrationBuilder.DropTable(
                name: "frequency_detail");

            migrationBuilder.DropTable(
                name: "reminderunit");

            migrationBuilder.DropTable(
                name: "report_review");

            migrationBuilder.DropTable(
                name: "reportsummary");

            migrationBuilder.DropTable(
                name: "taskassignees");

            migrationBuilder.DropTable(
                name: "taskunitassignment");

            migrationBuilder.DropTable(
                name: "userrole");

            migrationBuilder.DropTable(
                name: "reminder");

            migrationBuilder.DropTable(
                name: "progress");

            migrationBuilder.DropTable(
                name: "uploadfile");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "period");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "frequency");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "unituser");

            migrationBuilder.DropTable(
                name: "position");

            migrationBuilder.DropTable(
                name: "unit");

            migrationBuilder.DropTable(
                name: "org");
        }
    }
}
