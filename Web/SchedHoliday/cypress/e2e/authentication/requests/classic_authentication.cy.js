
describe('Try to connect with classic authentication', () => {


    beforeEach(() => {
        cy.visit("http://localhost:5173/")
    })

    it('Check data integrity when successfully connect', () => {
        cy.request({
            method: 'POST',
            url: 'https://porthos-intra.cg.helmo.be/Q210044/api/Authentication',
            body : {
                email: "auva@gmail.com",
                password:"Password_123"
            },
            failOnStatusCode : false
        })
            .should((response) => {
                expect(response.status).to.eq(200)
                expect(response.body).to.have.property('Id')
                expect(response.body).to.have.property('FirstName')
                expect(response.body).to.have.property('LastName')
                expect(response.body).to.have.property('Email')
                expect(response.body).to.have.property('Token')
            })
    })

})