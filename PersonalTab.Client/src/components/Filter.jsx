import React from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

class Filter extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      filter: {
        fullName: "",
        birthday: null,
      },
    };

    this.onChangeFullName = this.onChangeFullName.bind(this);
    this.onChangeBirthday = this.onChangeBirthday.bind(this);
    this.onSearch = this.onSearch.bind(this);
  }

  onChangeFullName(event) {
    this.setState({
      ...this.state,
      filter: {
        ...this.state.filter,
        fullName: event.target.value,
      },
    });
  }

  onChangeBirthday(event) {
    var birthday = null;

    if (event.target.value != "") birthday = event.target.value;

    this.setState({
      ...this.state,
      filter: {
        ...this.state.filter,
        birthday: birthday,
      },
    });
  }

  onSearch() {
    this.props.onSearch(this.state.filter);
    
  }

  render() {
    const { filter } = this.state;

    return (
      <div className="inputs">
        <div className="conteiner">
          <div className="input">
            <label className="label">ФИО</label>
            <Form.Control
            
            className="fullName"
              type="text"
              value={filter.fullName}
              onChange={this.onChangeFullName}
            />
          </div>
          <div className="input">
            <label className="label">Дата</label>
            <Form.Control
              type="date"
              value={filter.birthday}
              onChange={this.onChangeBirthday}
            />
          </div>
        </div>

        <div className="input">
          <Button className="mt-3" onClick={this.onSearch}> Поиск </Button>
        </div>
      </div>
    );
  }
}

export default Filter;
