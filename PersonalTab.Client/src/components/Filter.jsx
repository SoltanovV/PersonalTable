import React from "react";
import { GET_GENDERS_API } from "../api";

class Filter extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoaded: false,
      error: null,
      genders: [],
      filter: {
        firstName: null,
        lastName: null,
        patronymic: null,
        county: null,
        city: null,
        gender: 0,
      },
    };

    this.onChangeGender = this.onChangeGender.bind(this);
  }

  componentDidMount() {
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

  onChangeGender(event) {
    this.setState({
      ...this.state,
      filter: {
        ...this.state.filter,
        gender: event.target.value,
      },
    });
  }

  render() {
    const { isLoaded, genders, filter } = this.state;
    if (!isLoaded) {
      return <div>Loading...</div>;
    }

    return (
      <div className="inputs">
        {/* <div className="input">
          <label className="label">Название</label>
          <input
            type="text"
            value={this.state.name}
            onChange={this.onChangeName}
          />
        </div>
        <div className="input">
          <label className="label">Название</label>
          <input
            type="text"
            value={this.state.name}
            onChange={this.onChangeName}
          />
        </div>
        <div className="input">
          <label className="label">Название</label>
          <input
            type="text"
            value={this.state.name}
            onChange={this.onChangeName}
          />
        </div>
        <div className="input">
          <label className="label">Название</label>
          <input
            type="text"
            value={this.state.name}
            onChange={this.onChangeName}
          />
        </div>
        <div className="input">
          <label className="label">Название</label>
          <input
            type="text"
            value={this.state.name}
            onChange={this.onChangeName}
          />
        </div> */}
        <div className="input">
          <label className="label">Название</label>
          <select
            className="input-select"
            value={this.state.filter.gender}
            onChange={this.onChangeGender}
          >
            {genders.map((gender, key) => (
              <option key={key} value={key}>
                {gender}
              </option>
            ))}
          </select>
        </div>
      </div>
    );
  }
}

export default Filter;
