window.orgApi = {
  paths: {
    "/orgs": {
      get: {
        tags: ["Org"],
        summary: "Lấy danh sách tổ chức",
        responses: {
          200: {
            description: "Danh sách org",
            content: {
              "application/json": {
                schema: {
                  type: "array",
                  items: { $ref: "#/components/schemas/Org" }
                }
              }
            }
          }
        }
      },
      post: {
        tags: ["Org"],
        summary: "Tạo tổ chức",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/OrgCreate" }
            }
          }
        },
        responses: {
          201: { description: "Tạo org thành công" }
        }
      }
    },

    "/orgs/{orgId}": {
      put: {
        tags: ["Org"],
        summary: "Cập nhật org",
        parameters: [
          {
            name: "orgId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/OrgCreate" }
            }
          }
        },
        responses: {
          200: { description: "Cập nhật thành công" }
        }
      },
      delete: {
        tags: ["Org"],
        summary: "Xóa org",
        parameters: [
          {
            name: "orgId",
            in: "path",
            required: true,
            schema: { type: "integer" }
          }
        ],
        responses: {
          204: { description: "Xóa thành công" }
        }
      }
    }
  },

  components: {
    schemas: {
      Org: {
        type: "object",
        properties: {
          orgId: { type: "integer" },
          orgName: { type: "string" },
          parentOrgId: { type: "integer" },
          createdAt: { type: "string", format: "date-time" }
        }
      },
      OrgCreate: {
        type: "object",
        required: ["orgName"],
        properties: {
          orgName: { type: "string" },
          parentOrgId: { type: "integer" }
        }
      }
    }
  }
};
