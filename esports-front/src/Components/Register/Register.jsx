import React, { useState } from 'react';
import '../Login/Login.css'; // Reutilizando o mesmo CSS

const Register = ({ onRegister, onSwitchToLogin }) => {
  const [usuario, setUsuario] = useState('');
  const [senha, setSenha] = useState('');
  const [confirmarSenha, setConfirmarSenha] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (senha !== confirmarSenha) {
      alert('As senhas não coincidem!');
      return;
    }
    onRegister({ usuario, senha });
  };

  return (
    <div className="login-container">
      <h1>CADASTRO</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="usuario">Usuario</label>
          <input
            type="text"
            id="usuario"
            value={usuario}
            onChange={(e) => setUsuario(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="senha">Senha</label>
          <input
            type="password"
            id="senha"
            value={senha}
            onChange={(e) => setSenha(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="confirmarSenha">Confirmar Senha</label>
          <input
            type="password"
            id="confirmarSenha"
            value={confirmarSenha}
            onChange={(e) => setConfirmarSenha(e.target.value)}
          />
        </div>
        <button type="submit" className="submit-btn">CADASTRAR</button>
      </form>
      <p className="switch-text">
        Já tem uma conta? <span onClick={onSwitchToLogin}>Faça login</span>
      </p>
    </div>
  );
};

export default Register;