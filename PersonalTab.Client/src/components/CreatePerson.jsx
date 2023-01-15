import React from "react";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { GET_GENDERS_API, POST_CREATE_API } from "../api";

class CreatePerson extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      error: null,
      genders: [],
      form: {
        fullName: "",
        birthday: null,
        country: "",
        city: "",
        gender: 0,
      },
    };

    this.getGenders = this.getGenders.bind(this);
    this.onChangeFullName = this.onChangeFullName.bind(this);
    this.onChangeBirthday = this.onChangeBirthday.bind(this);
    this.onChangeCity = this.onChangeCity.bind(this);
    this.onChangeCountry = this.onChangeCountry.bind(this);
    this.onChangeGender = this.onChangeGender.bind(this);
    this.onCreate = this.onCreate.bind(this);
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

  onChangeFullName(event) {
    this.setState({
      ...this.state,
      form: {
        ...this.state.form,
        fullName: event.target.value,
      },
    });
  }

  onChangeBirthday(event) {
    this.setState({
      ...this.state,
      form: {
        ...this.state.form,
        birthday: event.target.value,
      },
    });
  }

  onChangeCountry(event) {
    this.setState({
      ...this.state,
      form: {
        ...this.state.form,
        country: event.target.value,
      },
    });
  }

  onChangeCity(event) {
    this.setState({
      ...this.state,
      form: {
        ...this.state.form,
        city: event.target.value,
      },
    });
  }

  onChangeGender(event) {
    this.setState({
      ...this.state,
      form: {
        ...this.state.form,
        gender: event.target.value,
      },
    });
  }

  onCreate() {
    fetch(POST_CREATE_API(), {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(this.state.form),
    })
  }

  render() {
    const { genders, form } = this.state;

    return (
      <div className="inputs">
        <div className="input">
          <label className="label">ФИО</label>
          <Form.Control
            type="text"
            value={form.fullName}
            onChange={this.onChangeFullName}
          />
        </div>
        <div className="input">
          <label className="label">Дата</label>
          <Form.Control
            type="date"
            value={form.birthday}
            onChange={this.onChangeBirthday}
          />
        </div>
        <div className="input">
          <label className="label">Город</label>
          <Form.Control type="text" value={form.city} onChange={this.onChangeCity} />
        </div>
        <div className="input">
          <label className="label">Страна</label>
          <Form.Control
            type="text"
            value={form.country}
            onChange={this.onChangeCountry}
          />
        </div>
        <div className="input">
          <label className="label">Пол</label>
          <Form.Select aria-label="Укажите пол"
            className="input-select"
            value={form.gender}
            onChange={this.onChangeGender}
          >
            {genders.map((gender, key) => (
              <option key={key} value={key}>
                {gender}
              </option>
            ))}
          </Form.Select>
        </div>
        <div className="input">
          <Button className="mt-4" onClick={this.onCreate}>Create</Button>
        </div>
      </div>
    );
  }
}

export default CreatePerson;
