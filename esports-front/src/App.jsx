import React, { useState } from 'react';
import Login from './Components/Login/Login';
import Register from './Components/Register/Register';

const App = () => {
  const [isLogin, setIsLogin] = useState(true);

  const handleLogin = (credentials) => {
    console.log('Login com:', credentials);
    
  };

  const handleRegister = (credentials) => {
    console.log('Registro com:', credentials);
    
  };

  return (
    <div className="app">
      {isLogin ? (
        <Login 
          onLogin={handleLogin} 
          onSwitchToRegister={() => setIsLogin(false)} 
        />
      ) : (
        <Register 
          onRegister={handleRegister} 
          onSwitchToLogin={() => setIsLogin(true)} 
        />
      )}
    </div>
  );
};

export default App;