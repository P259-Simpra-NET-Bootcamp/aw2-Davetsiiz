﻿using SimpApi.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpApi.Schema;

public class StaffRequest:BaseRequest
{
	public int	 Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string AddressLine1 { get; set; }
	public string City { get; set; }
	public string Country { get; set; }
	public string Province { get; set; }
}
