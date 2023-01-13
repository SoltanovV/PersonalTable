import React from "react";
import { POST_SEARCH_API } from "../api";

class Table extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: false,
      data: null,
      error: null,
    };
  }

  componentDidMount() {
    fetch(POST_SEARCH_API(2), {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        firstName: "string",
        lastName: "string",
        patronymic: "string",
        birthday: "2023-01-13T18:00:42.473Z",
      }),
    })
      .then((response) => response.json())
      .then((json) => {
        this.setState({
          ...this.state,
          isLoaded: true,
          data: json,
        });
      })
      .catch((error) => this.setState({ ...this.state, error: error }));
  }

  render() {
    const { isLoaded, data } = this.state;

    if (!isLoaded) {
      return <div>Loading...</div>;
    }

    return (
      <div>
        <table>
          <thead>
            <tr>
              <th>ФИО</th>
              <th>Дата</th>
              <th>Пол</th>
            </tr>
          </thead>
          <tbody>
            {data.map((person, key) => 
              <tr key={key}>
                <td>{person.firstName}</td>
                <td>a</td>
                <td>d</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    );
  }
}

export default Table;
