document.addEventListener('DOMContentLoaded', function(){
 
    const DoadorList= document.getElementById('Doador-lista');
 
    function renderTable(data){/*função para aparecer na tela */
        pessoaList.innerHTML='';
 
        data.forEach(Doador =>{
            const row = document.createElement('tr');
            row.innerHTML= `
<td>${Doador.PesoaId}</td>
<td>${Doador.primeiroNome}</td>
<td>${Doador.nomeMeio}</td>
<td>${Doador.ultimonOme}</td>
<td>${Doador.cpf}</td>
<td>
<button>Editar</button>
<button>Excluir</button>
</td>
            `;
            DoadorList.appendChild(row);
        })
    }
 
    function feachDoador(){
        fetch("http://localhost:5055/api/Pessoas/GetAll")
        .then(response => response.json())
        .then(data => renderTable(data))
        .catch(error => console.error('Erro ao buscar dados da API'))
    }
    feachDoador();
 
})
fetch('http://localhost:5055/api/Doador/Create',{
 
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