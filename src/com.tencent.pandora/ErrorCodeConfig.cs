using System;

namespace com.tencent.pandora
{
	internal class ErrorCodeConfig
	{
		public const int TNM2_TYPE_ACCUMULATION = 0;

		public const int TNM2_TYPE_AVERAGE = 1;

		public const int TNM2_TYPE_LITERALS = 2;

		public const int ASSET_PARSE_FAILED = 10217582;

		public const int MD5_VALIDATE_FAILED = 10217583;

		public const int FILE_WRITE_FAILED = 10217584;

		public const int ASSET_LOAD_FAILED = 10217586;

		public const int META_READ_FAILED = 10217587;

		public const int META_WRITE_FAILED = 10217588;

		public const int CGI_TIMEOUT = 10217590;

		public const int GAME_2_PANDORA_EXCEPTION = 10217591;

		public const int EXECUTE_LUA_CALLBACK_EXCEPTION = 10217592;

		public const int LUA_SCRIPT_EXCEPTION = 10217593;

		public const int LUA_DO_FILE_EXCEPTION = 10217594;

		public const int EXECUTE_ENTRY_LUA = 10217595;

		public const int PANDORA_2_GAME_EXCEPTION = 10217596;

		public const int SAME_PANEL_EXISTS = 10217597;

		public const int PANEL_PARENT_INEXISTS = 10217598;

		public const int COOKIE_WRITE_FAILED = 10217599;

		public const int COOKIE_READ_FAILED = 10217600;

		public const int DELETE_FILE_FAILED = 10217601;

		public const int START_RELOAD = 10217602;

		public const int LUA_SCRIPT_EXCEPTION_DETAIL = 10217603;

		public const int CGI_TIMEOUT_DETAIL = 10217604;
	}
}
