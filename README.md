# **CC4N - PROGRAMAÇÃO ORIENTADA A OBJETOS 2 - UVV**
### **University Computer Science Project in Object-Oriented Programming**
 - __Componentes:__ Gustavo Contarato Sant'anna, Leandro dos Santos de Abreu, Rafael Guimarães Vendros

---

### VÍDEO = https://youtu.be/hICMwXAhe-8

---

#### **Diretório dos arquivos:**
 - UML = /IMGS/UML.JPG
 - Banco de Dados = /CiA/bin/Debug/net5.0/cia.sqlite3

---

## ENTIDADES:
* **Cliente**
* **Endereco**
* **Colaborador**
* **Estoque**
* **Loja**
* **Venda**
* **Produto**

---

## **SOLID – Princípios da POO** (3 Utilizados)

### 1.	_**S — Single Responsibility Principle:**_
Consiste no princípio da responsabilidade única, isto é, uma classe deve ter apenas um motivo para mudar. Este princípio aponta que a classe deve ter apenas uma ação ou tarefa própria para executar. 
Utilizamos este princípio em algumas de nossas classes, visto que elas apresentam uma tarefa única. Cada uma é responsável por realizar as suas funções próprias.
Podemos citar como exemplo a classe “Clientes”, de cuja funcionalidade apenas o exercício do gerenciamento de Clientes cadastrados na loja, desde a sua criação e edição, até a sua remoção do sistema, caso haja necessidade. 
Tendo em vista esta funcionalidade, a classe citada, hierarquicamente falando, possuí apenas a permissão de se alterar, ou seja, ela se encontra no “pé” da hierarquia, sendo assim, não possui autoridade para realizar alterações em outras classes. 

### 2.	_**O — Open-Closed Principle:**_
Este princípio menciona que as entidades ou objetos da classe devem estar abertos para sua extensão, porém devem permanecer fechados para a modificação, isto é, quando novas funcionalidades necessitam de serem implementadas no software em questão, nós não devemos alterar todo o seu código fonte original, mas sim estendê-lo. Essa solução é realizada através da separação da extensão por trás de uma interface e invertendo as suas dependências.
Utilizamos este princípio em algumas de nossas classes, visto que elas apresentam uma abertura para serem estendidas, mas se encontram fechadas para a modificação, por exemplo podemos citar a classe “Loja” que tem seus atributos fechados para mudanças, porém tem métodos que o deixa ser adaptado.

### 3.	_**D — Dependency Inversion Principle**_
Neste princípio nós vemos que ela consiste em depender de abstrações ao invés de implementações, ou seja, um módulo presente no alto nível não pode depender de módulos inferiores, ambos precisam ser dependentes da abstração. Quando alteramos isto na classe o primeiro fator a ser analisado é esta hierarquia, identificando assim, os nódulos de alto e baixo nível.
Nós utilizamos este princípio para separarmos classes de alto nível e baixo nível, como é o caso da classe de conexão entre o programa e o banco de dados(alto nível) e o banco de dados em si(baixo nível).

---
