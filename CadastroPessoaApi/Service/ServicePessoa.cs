using CadastroPessoaApi.Data;
using CadastroPessoaApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CadastroPessoaApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();
            return repository.GetAll().ToList();
        }
        public PessoaViewModel GetById(int PessoaId)
        {
            var repository = new Repository();
            return repository.GetById(PessoaId);
        }
        public PessoaViewModel GetFirstName(string PrimeiroNome)
        {
            var repository = new Repository();
            return repository.GetFirstName(PrimeiroNome);
        }        
        
        public void update(int PessoaId, string PrimeiroNome)
        {
            if (PessoaId > 0 && !string.IsNullOrEmpty(PrimeiroNome))
            {
                var repository = new Repository();
                repository.update(PessoaId, PrimeiroNome);
            }
        }
        public string Create(PessoaViewModel pessoa) 
        {
            if (pessoa == null)
                return "os dois são obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.NomeMeio))
                return "o campo do nomemeio e obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.UltimonOme))
                return "os dois são obrigatorio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "os dois são obrigatorio";


            var repository = new Repository();
            return repository.Create(pessoa);


        }
           
    }
}