﻿using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalogo.Application.ViewModels
{
    public class CategoriaViewModel
    {
        #region Public Properties

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Codigo { get; set; }

        #endregion Public Properties
    }
}
