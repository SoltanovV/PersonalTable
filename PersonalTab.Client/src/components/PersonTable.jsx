import React from "react";
import CreatePerson from "./CreatePerson";
import Filter from "./Filter";
import Table from "./Table";
import { GET_ALL_PERSONS_API, POST_SEARCH_API } from "../api";

class PersonTable extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      persons: [],
      filter: {
        fullName: "",
        birthday: null,
      },
      pageCount: 0,
      pageNumber: 1,
    };

    this.getAllPersons = this.getAllPersons.bind(this);
    this.onPageNumberChange = this.onPageNumberChange.bind(this);
    this.onSearch = this.onSearch.bind(this);
  }

  componentDidMount() {
    this.getAllPersons();
  }

  getAllPersons() {
    fetch(POST_SEARCH_API(1), {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(this.state.filter),
    })
      .then((response) => response.json())
      .then((json) => {
        this.setState({
          ...this.state,
          isLoaded: true,
          persons: json.persons,
          pageCount: json.pageCount,
        });
      })
      .catch((error) => this.setState({ ...this.state, error: error }));
  }

  onPageNumberChange(pageNumber) {
    this.setState({ ...this.state, pageNumber: pageNumber }, () => {
      fetch(POST_SEARCH_API(this.state.pageNumber), {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(this.state.filter),
      })
        .then((response) => response.json())
        .then((json) => {
          this.setState({
            ...this.state,
            isLoaded: true,
            persons: json.persons,
            pageCount: json.pageCount,
          });
        })
        .catch((error) => this.setState({ ...this.state, error: error }));
    });
  }

  onSearch(filter) {
    this.setState({ ...this.state, filter: filter });

    fetch(POST_SEARCH_API(this.state.pageNumber), {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(this.state.filter),
    })
      .then((response) => response.json())
      .then((json) => {
        this.setState({
          ...this.state,
          isLoaded: true,
          persons: json.persons,
          pageCount: json.pageCount,
        });
      })
      .catch((error) => this.setState({ ...this.state, error: error }));
  }

  render() {
    const { persons, pageNumber, pageCount } = this.state;

    return (
      <>
        <Filter onSearch={this.onSearch} />
        <Table
          persons={persons}
          pageNumber={pageNumber}
          pageCount={pageCount}
          onPageNumberChange={this.onPageNumberChange}
        />
      </>
    );
  }
}

export default PersonTable;
