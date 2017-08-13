﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me
{
	public class ResponsePackage
	{
		public List<string> Errors { get; set; }

		public object Result { get; set; }
		public ResponsePackage(object result, List<string> errors)
		{
			Errors = errors;
			Result = result;
		}
	}
}