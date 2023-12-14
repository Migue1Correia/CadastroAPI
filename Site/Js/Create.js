function CreatePessoa(){
    const primeiroNome = document.getElementById(firstName).value;
    const segundoNome = document.getElementById(middleNome).value;
    const ultimoNome = document.getElementById(lestNome).value;
    const cpf = document.getElementById(CPF).value;

    const data ={
        primeiroNome:primeiroNome,
        nomeMeio:segundoNome,
        ultimonOme:ultimoNome,
        cpf:cpf,
    }
    fetch('http://localhost:5055/api/Pessoas/Create',{
 
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
    }).then(response => {
        if(!response.ok){
            alert("Erro ao criar pessoa");
        }
        alert("pessoa criada com sucesso!");
        window.location.href = '../index.html';
    })
    
}