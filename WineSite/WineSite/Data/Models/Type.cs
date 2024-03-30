﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static WineSite.Data.Constants.Type;
namespace WineSite.Data.Models
{
    [Comment("Type of wine")]
    public class Type
    {
        public Type()
        {
            MoreInformation = new List<MoreInformation>();
            Wines = new List<Wine>();
        }
        [Key]
        [Comment("Type Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Type Name")]
        public string Name  { get; set; } = null!;

        public IEnumerable<MoreInformation> MoreInformation { get; set; }

        public IEnumerable<Wine>Wines { get; set; }
        
    }
}
