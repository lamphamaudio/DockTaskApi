/* ======= auth.api.js ======= */
window.authApi = {
  paths: {
    "/auth/login": {
      post: {
        tags: ["Auth"],
        summary: "Đăng nhập",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/AuthLogin" }
            }
          }
        },
        responses: {
          200: {
            description: "JWT token",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/AuthResponse" }
              }
            }
          },
          401: { description: "Unauthorized" }
        }
      }
    },

    "/auth/logout": {
      post: {
        tags: ["Auth"],
        summary: "Đăng xuất (invalidate token)",
        security: [{ bearerAuth: [] }],
        responses: { 200: { description: "Đã logout" }, 401: { description: "Unauthorized" } }
      }
    },

    "/auth/refresh": {
      post: {
        tags: ["Auth"],
        summary: "Refresh token",
        requestBody: {
          required: true,
          content: {
            "application/json": {
              schema: { $ref: "#/components/schemas/AuthRefresh" }
            }
          }
        },
        responses: {
          200: {
            description: "New tokens",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/AuthResponse" }
              }
            }
          }
        }
      }
    },

    "/auth/me": {
      get: {
        tags: ["Auth"],
        summary: "Lấy thông tin user hiện tại",
        security: [{ bearerAuth: [] }],
        responses: {
          200: {
            description: "User hiện tại",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/User" }
              }
            }
          },
          401: { description: "Unauthorized" }
        }
      }
    }
  },

  components: {
    schemas: {
      AuthLogin: {
        type: "object",
        required: ["username", "password"],
        properties: {
          username: { type: "string" },
          password: { type: "string" }
        }
      },
      AuthRefresh: {
        type: "object",
        required: ["refreshToken"],
        properties: { refreshToken: { type: "string" } }
      },
      AuthResponse: {
        type: "object",
        properties: {
          accessToken: { type: "string" },
          refreshToken: { type: "string" },
          expiresIn: { type: "integer" }
        }
      }
    }
  }
};
