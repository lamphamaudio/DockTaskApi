/* ======= uploadfile.api.js ======= */
window.uploadfileApi = {
  paths: {
    "/files/upload": {
      post: {
        tags: ["File"],
        summary: "Upload file (multipart)",
        requestBody: {
          required: true,
          content: {
            "multipart/form-data": {
              schema: {
                type: "object",
                properties: {
                  file: { type: "string", format: "binary" },
                  taskId: { type: "integer" },
                  progressId: { type: "integer" }
                }
              }
            }
          }
        },
        responses: {
          201: {
            description: "Uploaded",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/UploadFile" }
              }
            }
          }
        }
      }
    },

    "/files/{fileId}": {
      get: {
        tags: ["File"],
        summary: "Tải file",
        parameters: [
          { name: "fileId", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: {
          200: {
            description: "File binary",
            content: {
              "application/octet-stream": { schema: { type: "string", format: "binary" } }
            }
          }
        }
      },
      delete: {
        tags: ["File"],
        summary: "Xóa file",
        parameters: [
          { name: "fileId", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: { 204: { description: "Deleted" } }
      }
    }
  },

  components: {
    schemas: {
      UploadFile: {
        type: "object",
        properties: {
          fileId: { type: "integer" },
          taskId: { type: "integer" },
          progressId: { type: "integer" },
          fileName: { type: "string" },
          filePath: { type: "string" },
          uploadedBy: { type: "integer" },
          uploadedAt: { type: "string", format: "date-time" }
        }
      }
    }
  }
};
