import http from 'k6/http'
import { check, sleep } from 'k6'
import { isStatus200, getHeaders } from '../utils/utils.js'

export const options = {
    vus: 20,
    duration: '30s'
}

const baseUrl = `${__ENV.BASE_URL}/v2`

export default function () {

  getFreeSchoolProjects()
  
  sleep(1)
}

function getFreeSchoolProjects() {
  const res = http.get(`${baseUrl}/fss/projects`, {
    headers: getHeaders()
  })

  isStatus200(res)
}
