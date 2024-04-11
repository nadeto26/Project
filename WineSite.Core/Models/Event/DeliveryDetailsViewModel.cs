﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WineSite.Core.Models.Event
{
    public class DeliveryDetailsViewModel
    {
        
        [Required(ErrorMessage = "Моля, въведете пълното си име.")]
        [Display(Name = "Пълно име")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете адрес за доставка.")]
        [Display(Name = "Адрес")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете имейла, с който се регистрирахте.")]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете град за доставка.")]
        [Display(Name = "Град")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Моля, въведете пощенски код.")]
        [Display(Name = "Пощенски код")]
        public string PostalCode { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}