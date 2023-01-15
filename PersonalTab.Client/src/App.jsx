import React from "react";
import PersonTable from "./components/PersonTable";
import { Routes, Route, Link } from "react-router-dom";
import CreatePerson from "./components/CreatePerson";

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div >
        <header className="container">
          <Link className="fs-4" to="/">Таблица</Link>
          <Link className="fs-4 d-inlineblock ms-3" to="/create">Создать запись</Link>
        </header>
        <div className="main container mt-5">
          <Routes>
            <Route path="/create" element={<CreatePerson />} />
            <Route path="/" element={<PersonTable />} />
          </Routes>
        </div>
      </div>
    );
  }
}

export default App;
