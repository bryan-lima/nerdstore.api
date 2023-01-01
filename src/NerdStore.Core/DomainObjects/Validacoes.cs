using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects
{
    public class Validacoes
    {
        #region Public Methods

        public static void ValidarSeIgual(object objeto1, object objeto2, string mensagem)
        {
            if (objeto1.Equals(objeto2))
                throw new DomainException(mensagem);
        }

        public static void ValidarSeDiferente(object objeto1, object objeto2, string mensagem)
        {
            if (!objeto1.Equals(objeto2))
                throw new DomainException(mensagem);
        }

        public static void ValidarSeDiferente(string padrao, string valor, string mensagem)
        {
            Regex _regex = new Regex(padrao);

            if (!_regex.IsMatch(valor))
                throw new DomainException(mensagem);
        }

        public static void ValidarTamanho(string valor, int maximo, string mensagem)
        {
            if (valor.Trim().Length > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarTamanho(string valor, int minimo, int maximo, string mensagem)
        {
            int _tamanho = valor.Trim().Length;

            if (_tamanho < minimo || _tamanho > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeNulo(object objeto, string mensagem)
        {
            if (objeto == null)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(long valor, long minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeFalso(bool valor, string mensagem)
        {
            if (!valor)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeVerdadeiro(bool valor, string mensagem)
        {
            if (valor)
                throw new DomainException(mensagem);
        }

        #endregion Public Methods
    }
}
