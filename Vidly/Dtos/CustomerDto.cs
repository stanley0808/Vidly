﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto //使用API時在前後台中間加入一個機制防止入侵
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入顧客名稱")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}