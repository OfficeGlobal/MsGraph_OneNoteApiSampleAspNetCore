﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OneNoteApiSample.Auth;

namespace OneNoteApiSample.Controllers
{
	public class MsGraphOauthCallbackController : Controller
	{
		// Initial HomePage
		public async Task<IActionResult> Index(string code)
		{
			if (string.IsNullOrEmpty(code))
			{
				throw new ArgumentException("code must be present!");
			}

			AuthTokenProperties tokenInformation = await MsGraphAuthUtils.Instance.ExchangeCodeForAccessToken(code);

			CookieUtils.StoreInCookie(tokenInformation, Response);

			// Redirect to API sample page
			return Redirect(ControllerRoutes.SampleApisPage);
		}
	}
}
