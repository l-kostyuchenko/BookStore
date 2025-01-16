﻿using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
	public static class DependencyInjectionExtension
	{
		public static void AddDependencies(this IServiceCollection services)
		{
			services.AddScoped<IBookService, BookService>();
		}
	}
}
