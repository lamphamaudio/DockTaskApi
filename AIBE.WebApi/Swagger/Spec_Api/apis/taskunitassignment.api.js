window.taskunitassignmentApi = {
  paths: {
    "/taskunitassignment": {
      get: {
        tags: ["TaskUnitAssignment"],
        summary: "Danh sách phân công task-unit",
        responses: {
          200: {
            description: "OK",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/TaskUnitAssignment" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["TaskUnitAssignment"],
        summary: "Tạo phân công",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/TaskUnitAssignmentCreate" }
            }
          }
        },
        responses: { 201: { description: "Created" } }
      }
    },

    "/taskunitassignments/{id}": {
      delete: {
        tags: ["TaskUnitAssignment"],
        parameters: [
          { name: "id", in: "path", required: true, schema: { type: "integer" } }
        ],
        responses: { 204: { description: "Deleted" } }
      }
    }
  },

  components: {
    schemas: {
      TaskUnitAssignment: {
        type: "object",
        properties: {
          id: { type: "integer" },
          taskId: { type: "integer" },
          unitId: { type: "integer" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      TaskUnitAssignmentCreate: {
        type: "object",
        required: ["taskId", "unitId"],
        properties: {
          taskId: { type: "integer" },
          unitId: { type: "integer" }
        }
      }
    }
  }
};
