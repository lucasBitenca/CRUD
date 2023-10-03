// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ShowToast() {
    const toastIndex = document.getElementById('msgToast');
    const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastIndex);
    toastBootstrap.show();
}
function ExcluirCliente() {
    confirm("Deseja realmente excluir o cliente?");
}
function validarCPF(cpf) {
    cpf = cpf.replace(/[^\d]+/g, ''); // Remove caracteres não numéricos
    if (cpf === '') return false; // CPF vazio é inválido

    // Verifica se o CPF tem 11 dígitos
    if (cpf.length !== 11) return false;

    // Verifica se todos os dígitos são iguais (CPF inválido, mas com formato correto)
    if (/^(\d)\1+$/.test(cpf)) return false;

    // Validação do primeiro dígito verificador
    let soma = 0;
    for (let i = 0; i < 9; i++) {
        soma += parseInt(cpf.charAt(i)) * (10 - i);
    }
    let resto = 11 - (soma % 11);
    let digitoVerificador1 = (resto === 10 || resto === 11) ? 0 : resto;

    if (digitoVerificador1 !== parseInt(cpf.charAt(9))) return false;

    // Validação do segundo dígito verificador
    soma = 0;
    for (let i = 0; i < 10; i++) {
        soma += parseInt(cpf.charAt(i)) * (11 - i);
    }
    resto = 11 - (soma % 11);
    let digitoVerificador2 = (resto === 10 || resto === 11) ? 0 : resto;

    if (digitoVerificador2 !== parseInt(cpf.charAt(10))) return false;

    return true;
}

document.addEventListener('DOMContentLoaded', function () {
    
    let formulario = document.getElementById('formCadastroCliente');
    formulario.addEventListener('submit', function (event) {
        const inputNome = $("#inputNome").val();
        const inputCPF = $("#inputCPF").val();
        const inputTipoCliente = $("#inputTipoCliente option:selected").val();
        const inputSexo = $("#inputSexo").val();
        const inputSituacaoCliente = $("#inputSituacaoCliente option:selected").val();
        if (inputNome.trim() === '') {
            let msg = 'Inserir um nome válido.';
            GerarExcecao(event, msg);
        }
        if (!validarCPF(inputCPF)) {
            let msg = 'Inserir um CPF válido.';
            GerarExcecao(event, msg);
        }
        if (inputTipoCliente == -1) {
            let msg = 'Inserir um tipo de cliente válido.';
            GerarExcecao(event, msg);
        }
        if (inputSexo.trim() === '') {
            let msg = 'Inserir um gênero válido.';
            GerarExcecao(event, msg);
        }
        if (inputSituacaoCliente == -1) {
            let msg = 'Inserir uma situação de cliente válida.';
            GerarExcecao(event, msg);
        }
    });
});
function GerarExcecao(event, msg) {
    $("#msgContent").prop('innerText', msg);
    ShowToast();
    event.preventDefault();
}