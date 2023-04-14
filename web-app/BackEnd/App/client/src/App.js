import logo from './logo.svg';
import './App.css';
import React from 'react';
import Dog from "./components/Dog";

function App() {
  const [data, setData] = React.useState(null);

  React.useEffect(() => {
    fetch("/api/hello")
      .then((res) => res.json())
      .then((data) => setData(data));
  }, []);

  return (
    <div className="App">
      <Dog data={data?.dogsName}/>
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>{!data?.message ? "Loading..." : data.message}</p>
      </header>
    </div>
  );
}


export default App;
