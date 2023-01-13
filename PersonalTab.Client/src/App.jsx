import React from "react";
import Filter from "./components/Filter";
import Table from "./components/Table";

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="main">
        <Filter />
        <Table />
      </div>
    );
  }
}

export default App;
