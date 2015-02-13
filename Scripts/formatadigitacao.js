//#### NUMEROS COM E SEM ESPAÇO #####################
function so_numeros(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '48') && (keyEntry <= '57')) || (keyEntry == '8') || (keyEntry == '14') || (keyEntry == '15') || (keyEntry == '27') || (keyEntry == '127'))
        return true;
    else {
        return false;
    }
}

function so_numeros_e_espaco(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '48') && (keyEntry <= '57')) || (keyEntry == '8') || (keyEntry == '32') || (keyEntry == '14') || (keyEntry == '15') || (keyEntry == '27') || (keyEntry == '127'))
        return true;
    else {
        return false;
    }
}

//########## NUMEROS E LETRAS COM E SEM ESPACO ###############

function numeros_e_letras(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '48') && (keyEntry <= '57')) || ((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '8') || (keyEntry == '32') || (keyEntry == '14') || (keyEntry == '15') || (keyEntry == '27') || (keyEntry == '127'))
        return true;
    else {
        return false;
    }
}

function numeros_e_letras_sem_espaco(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '48') && (keyEntry <= '57')) || ((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '8') || (keyEntry == '14') || (keyEntry == '15') || (keyEntry == '27') || (keyEntry == '127'))
        return true;
    else {
        return false;
    }
}

//############### SO LETRAS COM E SEM ESPACO #################

function so_letras(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '8') || (keyEntry == '14') || (keyEntry == '15') || (keyEntry == '27') || (keyEntry == '127'))
        return true;
    else {
        return false;
    }
}

function letras_e_espacos(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '32') || (keyEntry == '8') || (keyEntry == '14') || (keyEntry == '15') || (keyEntry == '27') || (keyEntry == '127'))
        return true;
    else {
        return false;
    }
}

//################# TUDO(LETRAS,CARACTERES ESPECIAIS, ETC) SEM NUMEROS ####################

function tudo_sem_numeros(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((KeyEntry >= '32') && (KeyEntry <= '47')) || ((KeyEntry >= '58') && (KeyEntry <= '126')) || (keyEntry == '8') || (keyEntry == '14') || (keyEntry == '15') || (keyEntry == '27') || (keyEntry == '127'))
        return true;
    else {
        return false;
    }
}

function tudo_sem_numeros_sem_espaco(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((KeyEntry >= '33') && (KeyEntry <= '47')) || ((KeyEntry >= '58') && (KeyEntry <= '126')) || (keyEntry == '8') || (keyEntry == '14') || (keyEntry == '15') || (keyEntry == '27') || (keyEntry == '127'))
        return true;
    else {
        return false;
    }
}


function MascaraDeData(str, textbox, separador) {
    {
        NewStr = "";
        for (var i = 0; i <= str.length; i++) {
            if (((str.charCodeAt(i) > 47) && (str.charCodeAt(i) < 58)) || ((str.charCodeAt(i) == 47) && ((i == 5) || (i == 2))))
                NewStr = NewStr + str.charAt(i);
        }
    }
    // alert ( 'x' + NewStr + 'x' );
    {
        for (var i = 0; i <= NewStr.length; i++) {
            if ((i == 2) || (i == 5)) {
                if (NewStr.substring(i, i + 1) != separador) {
                    if (event.keyCode != 8) { //backspace
                        NewStr = NewStr.substring(0, i) + separador + NewStr.substring(i, NewStr.length);
                    }
                }
            }
        }
    }
    textbox.value = NewStr
}



window.onload = function () {
    //####################apenas_emails
    document.getElementById("Corpo_EMail").onkeyup = function () {
        apenas_emails(document.getElementById("Corpo_EMail"));
    }
    //####################apenas_texto
    document.getElementById("Corpo_realname").onkeyup = function () {
        apenas_texto(document.getElementById("Corpo_realname"));
    }

    document.getElementById("Corpo_Endereco_Profissional").onkeyup = function () {
        apenas_texto(document.getElementById("Corpo_Endereco_Profissional"));
    }

    document.getElementById("Corpo_Endereco").onkeyup = function () {
        apenas_texto(document.getElementById("Corpo_Endereco"));
    }

    document.getElementById("Corpo_Cidade").onkeyup = function () {
        apenas_texto(document.getElementById("Corpo_Cidade"));
    }

    document.getElementById("Corpo_Cidade_Nascimento").onkeyup = function () {
        apenas_texto(document.getElementById("Cidade_Nascimento"));
    }

    document.getElementById("Corpo_Cidade_Profissional").onkeyup = function () {
        apenas_texto(document.getElementById("Corpo_Cidade_Profissional"));
    }
}
//####################apenas_emails
function apenas_emails(stringTeste) {
    palavra = new RegExp('^([0-9]|[@]|[.]|[a-zA-Z])$');
    (!palavra.test(stringTeste.value)) ? stringTeste.value = substStr(stringTeste, palavra) : "";
}
//####################apenas_texto
function apenas_texto(stringTeste) {
    palavra = new RegExp('\^([ã]|[Ã]|[é]|[É]|[ó]|[Ó]|[ô]|[Ô]|[õ]|[Õ]|[Ç]|[ç]|[a-zA-Z]|[ ])$');
    (!palavra.test(stringTeste.value)) ? stringTeste.value = substStrtexto(stringTeste, palavra) : "";
}
//####################apenas_emails
function substStr(teste, Lregex) {
    var str = "";
    var i = 0;
    Arr = new Array();
    result = teste.value;
    while (result.charAt(i)) {
        if (Lregex.test(result.charAt(i)))
            str += result.charAt(i);
        i++;
    }
    return str.toLowerCase();
}

//####################apenas_texto
function substStrtexto(teste, Lregex) {
    var str = "";
    var i = 0;
    Arr = new Array();
    result = teste.value;
    while (result.charAt(i)) {
        if (Lregex.test(result.charAt(i)))
            str += result.charAt(i);
        i++;
    }
    return str;
}
