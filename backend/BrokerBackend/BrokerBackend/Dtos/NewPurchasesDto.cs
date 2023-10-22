﻿using BrokerBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrokerBackend.Dtos
{
    public class NewPurchasesDto
    {
        public DateTime? PurchaseDate { get; set; } = DateTime.Today;

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public int? IdPerson { get; set; }

        public int? IdStock { get; set; }

        public StockModel? IdAccionNavigation { get; set; }

        public PersonModel? IdCuentaNavigation { get; set; }

    }
}
