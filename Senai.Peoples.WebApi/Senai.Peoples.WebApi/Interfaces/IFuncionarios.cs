using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarios
    {
        List<FuncionariosDomain> Listar();

        void Cadastrar(FuncionariosDomain funcionarios);
    }
}
