context('API requests', () => {
    beforeEach(() => {
        cy.visit('https://porthos-intra.cg.helmo.be/Q210044/swagger/index.html')
    })

    it('Check message received after failing trial', () => {
        cy.request({
            method: 'POST',
            url: 'https://porthos-intra.cg.helmo.be/Q210044/api/Authentication',
            body : {
                email: "this-user-doesnt-exists@void.dev",
                password:"incorrect-password"
            },
            failOnStatusCode : false
        })
            .should((response) => {
                expect(response.status).to.eq(400)
                expect(response.body).to.have.property('message').be.eq("Email or password incorrect")
            })
    })

    it('Check message received after locking out account', async () => {
        for(let i = 0; i <= 5; i++){
            await cy.request({
                method: 'POST',
                url: 'https://porthos-intra.cg.helmo.be/Q210044/api/Authentication',
                body : {
                    email: "auva@gmail.com",
                    password:"incorrect-password"
                },
                failOnStatusCode : false
            })
        }

        cy.request({
            method: 'POST',
            url: 'https://porthos-intra.cg.helmo.be/Q210044/api/Authentication',
            body : {
                email: "auva@gmail.com",
                password:"Password_123"
            },
            failOnStatusCode : false})
            .should((response) => {
                expect(response.status).to.eq(400)
                expect(response.body).to.have.property('message').be.eq("Your account is locked out for 5 minutes after failing 5 times.")
            })
    })
})