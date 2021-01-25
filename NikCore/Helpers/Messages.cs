using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikCore.Helpers
{
    public static class UserMessages
    {
        public static string DEFAULT => "Ocorreu um problema com o servidor, tente novamente mais tarde!";
        public static string NOT_FOUND => "Não Encontrado!";
    } 
    public static class DeveloperMessages
    {
        public static string DEFAULT => "Erro Desconhecido!";
        public static string EXEPTION(Exception e) => e.Message + "\n\n" + e.StackTrace;
        public static string NOT_FOUND => "Não Encontrado!";
        public static string NOT_ALLOWED => "Não Permitido!";
    }
}
