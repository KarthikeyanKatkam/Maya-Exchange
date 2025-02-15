using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Maya.Exchange.Controllers;
using Maya.Exchange.Models;
using Maya.Exchange.Services;
using Maya.Exchange.Middleware;

namespace Maya.Exchange.Routes
{
    public static class AuthRoutes
    {
        public static void MapAuthRoutes(this IEndpointRouteBuilder app)
        {
            // User registration endpoint
            app.MapPost("/auth/register", async ([FromBody] RegisterRequest request, IAuthService authService) =>
            {
                var result = await authService.RegisterUser(request);
                return Results.Ok(result);
            })
            .WithTags("Authentication")
            .WithName("Register");

            // User login endpoint
            app.MapPost("/auth/login", async ([FromBody] LoginRequest request, IAuthService authService) =>
            {
                var result = await authService.LoginUser(request);
                return Results.Ok(result);
            })
            .WithTags("Authentication")
            .WithName("Login");

            // KYC verification endpoints
            app.MapPost("/auth/kyc/submit", [Authorize] async ([FromBody] KycSubmissionRequest request, IKycService kycService) =>
            {
                var result = await kycService.SubmitKycDocuments(request);
                return Results.Ok(result);
            })
            .WithTags("KYC")
            .WithName("SubmitKyc");

            app.MapGet("/auth/kyc/status", [Authorize] async (IKycService kycService, HttpContext context) =>
            {
                var userId = context.User.FindFirst("sub")?.Value;
                var result = await kycService.GetKycStatus(userId);
                return Results.Ok(result);
            })
            .WithTags("KYC")
            .WithName("GetKycStatus");

            // Password reset endpoints
            app.MapPost("/auth/forgot-password", async ([FromBody] ForgotPasswordRequest request, IAuthService authService) =>
            {
                var result = await authService.InitiatePasswordReset(request);
                return Results.Ok(result);
            })
            .WithTags("Authentication")
            .WithName("ForgotPassword");

            app.MapPost("/auth/reset-password", async ([FromBody] ResetPasswordRequest request, IAuthService authService) =>
            {
                var result = await authService.ResetPassword(request);
                return Results.Ok(result);
            })
            .WithTags("Authentication")
            .WithName("ResetPassword");

            // 2FA endpoints
            app.MapPost("/auth/2fa/enable", [Authorize] async (IAuthService authService, HttpContext context) =>
            {
                var userId = context.User.FindFirst("sub")?.Value;
                var result = await authService.Enable2FA(userId);
                return Results.Ok(result);
            })
            .WithTags("Authentication")
            .WithName("Enable2FA");

            app.MapPost("/auth/2fa/verify", [Authorize] async ([FromBody] Verify2FARequest request, IAuthService authService) =>
            {
                var result = await authService.Verify2FA(request);
                return Results.Ok(result);
            })
            .WithTags("Authentication")
            .WithName("Verify2FA");

            // Session management
            app.MapPost("/auth/logout", [Authorize] async (IAuthService authService, HttpContext context) =>
            {
                var userId = context.User.FindFirst("sub")?.Value;
                await authService.LogoutUser(userId);
                return Results.Ok();
            })
            .WithTags("Authentication")
            .WithName("Logout");

            app.MapGet("/auth/session", [Authorize] async (IAuthService authService, HttpContext context) =>
            {
                var userId = context.User.FindFirst("sub")?.Value;
                var result = await authService.GetSessionInfo(userId);
                return Results.Ok(result);
            })
            .WithTags("Authentication")
            .WithName("GetSessionInfo");
        }
    }
}
