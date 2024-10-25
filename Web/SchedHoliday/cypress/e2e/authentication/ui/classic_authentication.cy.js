describe('Try to connect with classic authentication', () => {
  beforeEach(() => {
    cy.visit("http://localhost:5173/connexion")
  })

  it('Authenticate successfully', () => {

    cy.get('#email').type("auva@gmail.com")
    cy.get('#password').type("Password_123")
    cy.get("form").submit()
    cy.url().should('eq', 'http://localhost:5173/')
  })
})
