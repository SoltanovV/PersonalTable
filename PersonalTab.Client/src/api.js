const BASE_URL = "https://localhost:7056/api";

const PERSON_CONTROLLER = "/person";

export const POST_CREATE_API = () =>
    BASE_URL + PERSON_CONTROLLER + `/create`;
export const POST_SEARCH_API = (pageNumber) =>
    BASE_URL + PERSON_CONTROLLER + `/search/${pageNumber}`;
export const GET_GENDERS_API = () =>
    BASE_URL + PERSON_CONTROLLER + `/genders`;