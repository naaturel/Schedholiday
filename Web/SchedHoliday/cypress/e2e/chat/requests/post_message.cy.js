import {da} from "date-fns/locale";

describe('Send message', () => {

    let user = null
    let holiday = null

    beforeEach(() => {
        cy.visit("http://localhost:5173/")
        cy.request({
            method: 'POST',
            url: 'https://porthos-intra.cg.helmo.be/Q210044/api/Authentication',
            body : {
                email: "auva@gmail.com",
                password:"Password_123"
            },
            failOnStatusCode : false
        }).then(response => {
            return response.body
        }).then(data =>
            user = data
        )

        cy.request({
            method: 'GET',
            url: 'https://porthos-intra.cg.helmo.be/Q210044/api/Holiday',
            failOnStatusCode : false
        }).then(response => {
            return response.body
        }).then(data =>
            holiday = JSON.parse(data)[0]
        )

    })

    it('Successfully send message', () => {

        console.log(user)

        cy.request({
            method: 'POST',
            url: `https://porthos-intra.cg.helmo.be/Q210044/api/Chat/`,
            headers : {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${user.Token}`
            },
            body : {
                content: "Test de Julien",
                epoch : Math.floor(new Date().getTime() / 1000),
                sender: user.id,
                holidayId: holiday.id
            },
            failOnStatusCode : false
        }).should((response) => {
            expect(response.status).to.eq(200)
        })
    })

    it('Send message without authorization', () => {

        console.log(user)

        cy.request({
            method: 'POST',
            url: `https://porthos-intra.cg.helmo.be/Q210044/api/Chat/`,
            headers : {
                'Content-Type': 'application/json',
            },
            body : {
                content: "Test de Julien",
                epoch : Math.floor(new Date().getTime() / 1000),
                sender: user.id,
                holidayId: holiday.id
            },
            failOnStatusCode : false
        }).should((response) => {
            expect(response.status).to.eq(401)
        })
    })

})