/* ======= report_summary.api.js ======= */
window.reportSummaryApi = {
  paths: {
    "/reports/summary": {
      get: {
        tags: ["ReportSummary"],
        summary: "Lấy báo cáo tổng hợp",
        parameters: [
          { name: "taskId", in: "query", schema: { type: "integer" } },
          { name: "periodId", in: "query", schema: { type: "integer" } }
        ],
        responses: {
          200: {
            description: "Summary",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/ReportSummary" }
              }
            }
          }
        }
      }
    },

    "/reports/summary/generate": {
      post: {
        tags: ["ReportSummary"],
        summary: "Tạo/tổng hợp báo cáo (AI)",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/ReportSummaryCreate" }
            }
          }
        },
        responses: {
          201: {
            description: "Created",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/ReportSummary" }
              }
            }
          }
        }
      }
    }
  },

  components: {
    schemas: {
      ReportSummary: {
        type: "object",
        properties: {
          reportId: { type: "integer" },
          taskId: { type: "integer" },
          periodId: { type: "integer" },
          summary: { type: "string" },
          createdBy: { type: "integer" },
          reportFile: { type: "integer" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      ReportSummaryCreate: {
        type: "object",
        required: ["taskId", "periodId"],
        properties: {
          taskId: { type: "integer" },
          periodId: { type: "integer" }
        }
      }
    }
  }
};
