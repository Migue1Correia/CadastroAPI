document.addEventListener('DOMContentLoaded', function(){
 
    const pessoaList= document.getElementById('pessoa-lista');
 
    function renderTable(data){/*função para aparecer na tela */
        pessoaList.innerHTML='';
 
        data.forEach(pessoa =>{
            const row = document.createElement('tr');
            row.innerHTML= `
<td>${pessoa.PesoaId}</td>
<td>${pessoa.primeiroNome}</td>
<td>${pessoa.nomeMeio}</td>
<td>${pessoa.ultimonOme}</td>
<td>${pessoa.cpf}</td>
<td>
<button>Editar</button>
<button>Excluir</button>
</td>
            `;
            pessoaList.appendChild(row);
        })
    }
 
    function feachPessoas(){
        fetch("http://localhost:5055/api/Pessoas/GetAll")
        .then(response => response.json())
        .then(data => renderTable(data))
        .catch(error => console.error('Erro ao buscar dados da API'))
    }
    feachPessoas();
 
})
fetch('http://localhost:5055/api/Pessoas/Create',{
 
method: 'post',
headers: {
    'content-type': 'application/json'
},
}).then(response => {
    if(!response.ok){
        alert("Erro ao criar pessoa");
    }
    alert("pessoa criada com sucesso!");
    window.location.href = 'index.html';
})