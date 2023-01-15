import React from "react";
import { GET_GENDERS_API } from "../api";
import { Table as BootstrapTable } from "react-bootstrap"

class Table extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      genders: [],
      sortConfing: {
        column: "fullName",
        state: 0,
      },
    };

    this.getGenders = this.getGenders.bind(this);
    this.onChangePage = this.onChangePage.bind(this);
    this.onSort = this.onSort.bind(this);
    this.personsSorting = this.personsSorting.bind(this);
  }

  componentDidMount() {
    this.getGenders();
  }

  getGenders() {
    fetch(GET_GENDERS_API(), {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    })
      .then((response) => response.json())
      .then((json) => {
        this.setState({
          ...this.state,
          isLoaded: true,
          genders: json,
        });
      })
      .catch((error) => this.setState({ ...this.state, error: error }));
  }

  onChangePage(event) {
    this.props.onPageNumberChange(event.target.value);
  }

  onSort(sortColumn) {
    let sortColumnState = 1;

    if (this.state.sortConfing.column == sortColumn) {
      if (this.state.sortConfing.state < 1)
        sortColumnState = this.state.sortConfing.state + 1;
      else sortColumnState = 0;
    }

    this.setState({
      ...this.state,
      sortConfing: { column: sortColumn, state: sortColumnState },
    });
  }

  personsSorting(sortConfing, persons) {
    let sortedPersons = persons.sort((a, b) => {
      return a[sortConfing.column] < b[sortConfing.column]
        ? -1
        : a[sortConfing.column] > b[sortConfing.column]
        ? 1
        : 0;
    });

    if (sortConfing.state == 1) sortedPersons.reverse();

    return sortedPersons;
  }

  render() {
    const { genders, sortConfing } = this.state;
    const { persons, pageCount, pageNumber } = this.props;

    const sortedPersons = this.personsSorting(sortConfing, persons);

    if (persons.count == 0) {
      return <div>Loading...</div>;
    }

    const pages = [];

    for (let i = 1; i < pageCount + 1; i++) {
      pages.push(
        <option key={i} value={i}>
          {i}
        </option>
      );
    }

    return (
      <div>
        <BootstrapTable striped bordered hover>
          <thead>
            <tr>
              <th onClick={(e) => this.onSort("fullName")}>ФИО</th>
              <th onClick={(e) => this.onSort("birthday")}>Дата</th>
              <th onClick={(e) => this.onSort("gender")}>Пол</th>
              <th onClick={(e) => this.onSort("city")}>Страна</th>
              <th onClick={(e) => this.onSort("country")}>Город</th>
            </tr>
          </thead>
          <tbody>
            {sortedPersons.map((person, key) => (
              <tr key={key}>
                <td>{person.fullName}</td>
                <td>{new Date(person.birthday).toLocaleDateString("ru-Ru")}</td>
                <td>{genders[person.gender]}</td>
                <td>{person.country}</td>
                <td>{person.city}</td>
              </tr>
            ))}
          </tbody>
          <tfoot>
            <div className="input">
              <label className="label">Page</label>
              <select
                className="input-select"
                value={pageNumber}
                onChange={this.onChangePage}
              >
                {pages}
              </select>
            </div>
          </tfoot>
        </BootstrapTable>
      </div>
    );
  }
}

export default Table;
